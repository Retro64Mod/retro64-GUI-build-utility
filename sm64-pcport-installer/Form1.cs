using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using IWshRuntimeLibrary;
using sm64_pcport_installer.Properties;

namespace sm64_pcport_installer
{
    public partial class Main : Form
    {
        private string sourceRepo= "libsm64-retro64";
        private string sourceRepoURL;
        private string baseArgs;
        private string repoDir;
        private string portPath;
        private string logDir="";

        private Boolean advanced;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            loadSettings();

            if (advanced)
            {
                this.advancedBar.Image = Resources.advanced_open;
                this.panelAdvanced.Show();
            }
            else
            {
                this.advancedBar.Image = Resources.advanced_closed;
                this.panelAdvanced.Hide();
            }
            sourceRepoURL = "https://github.com/Retro64Mod/libsm64-retro64.git";
            verCombo.Items.Clear();
        }

        private void Main_FormClosing(object sender, FormClosedEventArgs e)
        {
            // Save user settings prior to closing
            saveSettings();

        }

        private string[] getVersions()
        {
            addToLog("Getting versions...");
            var tagsStr = executeMSYS2($@"git ls-remote --sort='version:refname' --tags {sourceRepoURL} | sed -E 's/^[[:xdigit:]]+[[:space:]]+refs\/tags\/(.+)/\1/g'");
            List<string> tags = new List<string>();
            // Split tags into separate lines, add to tags list
            tags.AddRange(tagsStr.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
            tags.RemoveAll(str => str.EndsWith("^{}"));
            if (tags.Count == 0 || (tags.Count == 1 && string.IsNullOrEmpty(tags[0])))
                return new string[] { };
            return tags.ToArray();
        }

        private void checkDepend_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Dependency update check was set to " + this.checkDepend.Checked + "\n";
        }

        private void jobNumber_ValueChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Number of jobs allocated was set to " + this.jobNumber.Value + "\n";
        }

        private void buttonMSYS2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textMSYS2.Text = folderBrowserDialog1.SelectedPath;

                // Log action
                this.outputText.Text += "Changed the MSYS2 directory to:\n" + this.textMSYS2.Text + "\n";
            }
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {
            this.outputText.SelectionStart = this.outputText.Text.Length;
            this.outputText.ScrollToCaret();
        }

        private void checkTerm_CheckedChanged(object sender, EventArgs e)
        {
            this.checkLog.Enabled = this.checkTerm.Checked;

            if (!this.checkTerm.Checked)
            {
                this.checkLog.Checked = false;
            }

            //Log action taken
            this.outputText.Text += "Terminal display was changed to " + this.checkTerm.Checked + "\n";
        }

        private void checkLog_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Leave log open changed to " + this.checkLog.Checked + "\n";
        }

        private void updateBaseArgs()
        {
            baseArgs = null;

            // Check if terminal should be shown to the user
            if (!checkTerm.Checked)
            {
                // Log action
                this.outputText.Text += "Configuring for hidden terminal...\n";

                baseArgs += "-w hide ";
            }

            // Check if log should remain open after completion
            if (checkLog.Checked)
            {
                // Log action
                this.outputText.Text += "Configuring for holding terminal...\n";

                baseArgs += "-h always ";
            }

            baseArgs += "/bin/env MSYSTEM=MINGW64 /bin/bash -l -c \"";
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            if (verCombo.Items.Count == 0)
            {
                MessageBox.Show("Please wait until versions are loaded.");
                return;
            }
            if (verCombo.SelectedIndex == -1)
                verCombo.SelectedIndex = 0; // select latest
            // Check for existing backup folder and create if not found

            // Set up repository and logging directory path
            repoDir = Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, sourceRepo);
            portPath = Path.Combine(repoDir, "dist");
            

            addToLog(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            addToLog("----------------------------------------");
            addToLog("Pre-compile log dump:");
            addToLog(this.outputText.Text);
            addToLog("\nMSYS2 calls:");

            this.outputText.Text += "Configuring MSYS2 process...\n";
            updateBaseArgs();

            // Check for dependency updates via pacman
            if (this.checkDepend.Checked)
            {
                // Log action
                this.outputText.Text += "Checking for dependency udpates via pacman...\n";

                executeMSYS2("pacman -S --needed --noconfirm git make python3 mingw-w64-x86_64-gcc");

                // Log action
                this.outputText.Text += "Dependencies are up-to-date.\n";
            }
            
            updateRepository();

            // Log action
            this.outputText.Text += "Checking for baserom...\n";

            // Log make action
            this.outputText.Text += "This could take several minutes.\n";
            this.outputText.Text += "When the process is completed ";
            this.outputText.Text += "the directory containing the executable will be opened.\n";
            

            object desktop = (object)"Desktop";

            string compileCommand = "cd ./" + sourceRepo + " && make";

            if (this.jobNumber.Value > 0)
            {
                // Log number of jobs used
                this.outputText.Text += "Compiling executable with " + jobNumber.Value + " jobs allocated...\n";

                compileCommand += " -j" + jobNumber.Value;
            }
            else
            {
                // Log number of jobs used
                this.outputText.Text += "Compiling executable with unlimited jobs allocated...\n";
            }

            //compileCommand += "'";

            executeMSYS2(compileCommand, true);

            addToLog("----------------------------------------\n\n");

            if (!logDir.Equals(repoDir))
            {
                System.IO.File.Move(Path.Combine(logDir, "build.log"), Path.Combine(repoDir, "build.log"));
            }


            Process.Start(portPath);
            this.outputText.Text += portPath + " opened.\n";
            
        }

        private string executeMSYS2(string commands)
        {
            updateBaseArgs();
            // Set up individual processes
            Process mintty = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands + " |& tee msys2.log\"";

            // Add call to log file
            addToLog(minttyStart.FileName);
            addToLog(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();
            Thread.Sleep(100);
            while (mintty.StartTime == null)
            {
                Thread.Sleep(10);
            }
            mintty.StandardOutput.ReadToEnd();
            var output= System.IO.File.ReadAllText(Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, "msys2.log"));
            this.outputText.Text += output;
            return output;
        }

        private void executeMSYS2(string commands, Boolean compile)
        {
            // Set up individual processes
            Process mintty = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands + " |& tee msys2.log\"";

            // Add call to log file
            addToLog(minttyStart.FileName);
            addToLog(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();

            Thread.Sleep(100);

            string dirCount;
            string logPath;
            dirCount = Path.Combine(portPath,"..");
            compileProgress.Maximum = 2;
            compileProgress.Minimum = 0;
            

            if (commands.Contains("cd ./"))
            {
                logPath = Path.Combine(repoDir, "msys2.log");
            }
            else
            {
                logPath = Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, "msys2.log");
            }

            while (!Directory.Exists(dirCount))
            {
                Thread.Sleep(10);
            }

            while ((Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length < compileProgress.Maximum))
            {
                try
                {
                    using (FileStream logStream = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader logReader = new StreamReader(logStream))
                    {
                        this.outputText.Text = logReader.ReadToEnd();
                    }
                }
                catch { }

                try
                {
                    compileProgress.Value = Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length;
                }
                catch
                {
                    compileProgress.Value = compileProgress.Maximum;
                }
            }
            mintty.StandardOutput.ReadToEnd();
            compileProgress.Value = compileProgress.Minimum;
        }

        private void advancedBar_Click(object sender, EventArgs e)
        {
            if (advanced)
            {
                this.advancedBar.Image = Resources.advanced_closed;
                this.panelAdvanced.Hide();
            }
            else
            {
                this.advancedBar.Image = Resources.advanced_open;
                this.panelAdvanced.Show();
            }
            advanced = !advanced;
        }

        private void verCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "VERSION build option set to " + this.verCombo.Text + "\n";
        }

        

        private void saveSettings()
        {
            if (this.checkDepend.Enabled) Settings.Default.updateMSY2 = this.checkDepend.Checked;
            if (this.jobNumber.Enabled) Settings.Default.jobNum = (int)this.jobNumber.Value;
            if (this.textMSYS2.Enabled) Settings.Default.msys2 = this.textMSYS2.Text;
            if (this.checkTerm.Enabled) Settings.Default.terminal = this.checkTerm.Checked;
            if (this.checkLog.Enabled) Settings.Default.log = this.checkLog.Checked;
            Settings.Default.advanced = this.advanced;
            Settings.Default.Save();
        }

        private void loadSettings()
        {
            this.checkDepend.Checked = Settings.Default.updateMSY2;
            if (Settings.Default.jobNum < 0)
            {
                int jobCount = Environment.ProcessorCount - 2;
                if (jobCount < 1) jobCount = 2;
                this.jobNumber.Value = jobCount;
            }
            else
            {
                this.jobNumber.Value = Settings.Default.jobNum;
            }
            if (Directory.Exists(Settings.Default.msys2))
            {
                this.textMSYS2.Text = Settings.Default.msys2;
            }
            else
            {
                this.textMSYS2.Text = @"C:\msys64";
            }
            this.checkTerm.Checked = Settings.Default.terminal;
            this.checkLog.Checked = Settings.Default.log;
            this.advanced = Settings.Default.advanced;
        }

        private void updateRepository()
        {
            if (Directory.Exists(repoDir))
            {
                executeMSYS2($"rm -rf {sourceRepo}");
            }
            // Log cloning action
            this.outputText.Text += "Cloning from " + sourceRepo + " repository...\n";
            this.outputText.Text += "Connecting to " + sourceRepoURL + "\n";
            
            executeMSYS2($"git clone {sourceRepoURL} --depth 1 --branch {verCombo.Text} {sourceRepo}", true);

            // Log action
            this.outputText.Text += sourceRepo + " repository cloned.\n";
            
        }

        private void addToLog(string input)
        {
            using (StreamWriter logFile = new StreamWriter(Path.Combine(logDir, "build.log"),true))
            {
                logFile.WriteLine(input);
            }
        }

        private void getVersBtn_Click(object sender, EventArgs e)
        {
            // Check for dependency updates via pacman
            if (this.checkDepend.Checked)
            {
                // Log action
                this.outputText.Text += "Checking for dependency udpates via pacman...\n";

                executeMSYS2("pacman -S --needed --noconfirm git make python3 mingw-w64-x86_64-gcc");

                // Log action
                this.outputText.Text += "Dependencies are up-to-date.\n";
            }
            var vers = getVersions();
            verCombo.Items.Clear();
            verCombo.Items.AddRange(vers);
        }
    }
}
