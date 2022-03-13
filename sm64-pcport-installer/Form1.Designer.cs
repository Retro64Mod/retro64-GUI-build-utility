namespace sm64_pcport_installer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.outputText = new System.Windows.Forms.RichTextBox();
            this.jobLabel = new System.Windows.Forms.Label();
            this.jobNumber = new System.Windows.Forms.NumericUpDown();
            this.checkDepend = new System.Windows.Forms.CheckBox();
            this.sm64PortLogo = new System.Windows.Forms.PictureBox();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.labelMSYS2 = new System.Windows.Forms.Label();
            this.textMSYS2 = new System.Windows.Forms.TextBox();
            this.buttonMSYS2 = new System.Windows.Forms.Button();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.checkTerm = new System.Windows.Forms.CheckBox();
            this.compileProgress = new System.Windows.Forms.ProgressBar();
            this.advancedBar = new System.Windows.Forms.PictureBox();
            this.panelSimple = new System.Windows.Forms.Panel();
            this.getVersBtn = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.verCombo = new System.Windows.Forms.ComboBox();
            this.panelAdvanced = new System.Windows.Forms.Panel();
            this.makeGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedBar)).BeginInit();
            this.panelSimple.SuspendLayout();
            this.panelAdvanced.SuspendLayout();
            this.makeGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputText
            // 
            resources.ApplyResources(this.outputText, "outputText");
            this.outputText.Name = "outputText";
            this.toolTipMain.SetToolTip(this.outputText, resources.GetString("outputText.ToolTip"));
            this.outputText.TextChanged += new System.EventHandler(this.outputText_TextChanged);
            // 
            // jobLabel
            // 
            resources.ApplyResources(this.jobLabel, "jobLabel");
            this.jobLabel.Name = "jobLabel";
            this.toolTipMain.SetToolTip(this.jobLabel, resources.GetString("jobLabel.ToolTip"));
            // 
            // jobNumber
            // 
            resources.ApplyResources(this.jobNumber, "jobNumber");
            this.jobNumber.Name = "jobNumber";
            this.toolTipMain.SetToolTip(this.jobNumber, resources.GetString("jobNumber.ToolTip"));
            this.jobNumber.ValueChanged += new System.EventHandler(this.jobNumber_ValueChanged);
            // 
            // checkDepend
            // 
            resources.ApplyResources(this.checkDepend, "checkDepend");
            this.checkDepend.Name = "checkDepend";
            this.toolTipMain.SetToolTip(this.checkDepend, resources.GetString("checkDepend.ToolTip"));
            this.checkDepend.UseVisualStyleBackColor = true;
            this.checkDepend.CheckedChanged += new System.EventHandler(this.checkDepend_CheckedChanged);
            // 
            // sm64PortLogo
            // 
            this.sm64PortLogo.Image = global::sm64_pcport_installer.Properties.Resources.retro64logo;
            resources.ApplyResources(this.sm64PortLogo, "sm64PortLogo");
            this.sm64PortLogo.Name = "sm64PortLogo";
            this.sm64PortLogo.TabStop = false;
            // 
            // buttonCompile
            // 
            resources.ApplyResources(this.buttonCompile, "buttonCompile");
            this.buttonCompile.Name = "buttonCompile";
            this.toolTipMain.SetToolTip(this.buttonCompile, resources.GetString("buttonCompile.ToolTip"));
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // labelMSYS2
            // 
            resources.ApplyResources(this.labelMSYS2, "labelMSYS2");
            this.labelMSYS2.Name = "labelMSYS2";
            this.toolTipMain.SetToolTip(this.labelMSYS2, resources.GetString("labelMSYS2.ToolTip"));
            // 
            // textMSYS2
            // 
            resources.ApplyResources(this.textMSYS2, "textMSYS2");
            this.textMSYS2.Name = "textMSYS2";
            this.toolTipMain.SetToolTip(this.textMSYS2, resources.GetString("textMSYS2.ToolTip"));
            // 
            // buttonMSYS2
            // 
            resources.ApplyResources(this.buttonMSYS2, "buttonMSYS2");
            this.buttonMSYS2.Name = "buttonMSYS2";
            this.toolTipMain.SetToolTip(this.buttonMSYS2, resources.GetString("buttonMSYS2.ToolTip"));
            this.buttonMSYS2.UseVisualStyleBackColor = true;
            this.buttonMSYS2.Click += new System.EventHandler(this.buttonMSYS2_Click);
            // 
            // checkLog
            // 
            resources.ApplyResources(this.checkLog, "checkLog");
            this.checkLog.Name = "checkLog";
            this.toolTipMain.SetToolTip(this.checkLog, resources.GetString("checkLog.ToolTip"));
            this.checkLog.UseVisualStyleBackColor = true;
            this.checkLog.CheckedChanged += new System.EventHandler(this.checkLog_CheckedChanged);
            // 
            // labelLog
            // 
            resources.ApplyResources(this.labelLog, "labelLog");
            this.labelLog.Name = "labelLog";
            // 
            // checkTerm
            // 
            resources.ApplyResources(this.checkTerm, "checkTerm");
            this.checkTerm.Name = "checkTerm";
            this.toolTipMain.SetToolTip(this.checkTerm, resources.GetString("checkTerm.ToolTip"));
            this.checkTerm.UseVisualStyleBackColor = true;
            this.checkTerm.CheckedChanged += new System.EventHandler(this.checkTerm_CheckedChanged);
            // 
            // compileProgress
            // 
            resources.ApplyResources(this.compileProgress, "compileProgress");
            this.compileProgress.Name = "compileProgress";
            this.compileProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // advancedBar
            // 
            this.advancedBar.Image = global::sm64_pcport_installer.Properties.Resources.advanced_closed;
            resources.ApplyResources(this.advancedBar, "advancedBar");
            this.advancedBar.InitialImage = global::sm64_pcport_installer.Properties.Resources.advanced_closed;
            this.advancedBar.Name = "advancedBar";
            this.advancedBar.TabStop = false;
            this.toolTipMain.SetToolTip(this.advancedBar, resources.GetString("advancedBar.ToolTip"));
            this.advancedBar.Click += new System.EventHandler(this.advancedBar_Click);
            // 
            // panelSimple
            // 
            resources.ApplyResources(this.panelSimple, "panelSimple");
            this.panelSimple.Controls.Add(this.getVersBtn);
            this.panelSimple.Controls.Add(this.advancedBar);
            this.panelSimple.Controls.Add(this.versionLabel);
            this.panelSimple.Controls.Add(this.buttonCompile);
            this.panelSimple.Controls.Add(this.verCombo);
            this.panelSimple.Controls.Add(this.sm64PortLogo);
            this.panelSimple.Controls.Add(this.compileProgress);
            this.panelSimple.Controls.Add(this.labelMSYS2);
            this.panelSimple.Controls.Add(this.textMSYS2);
            this.panelSimple.Controls.Add(this.outputText);
            this.panelSimple.Controls.Add(this.checkDepend);
            this.panelSimple.Controls.Add(this.buttonMSYS2);
            this.panelSimple.Controls.Add(this.jobLabel);
            this.panelSimple.Controls.Add(this.labelLog);
            this.panelSimple.Controls.Add(this.jobNumber);
            this.panelSimple.Name = "panelSimple";
            // 
            // getVersBtn
            // 
            resources.ApplyResources(this.getVersBtn, "getVersBtn");
            this.getVersBtn.Name = "getVersBtn";
            this.getVersBtn.UseVisualStyleBackColor = true;
            this.getVersBtn.Click += new System.EventHandler(this.getVersBtn_Click);
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            this.toolTipMain.SetToolTip(this.versionLabel, resources.GetString("versionLabel.ToolTip"));
            // 
            // verCombo
            // 
            this.verCombo.FormattingEnabled = true;
            this.verCombo.Items.AddRange(new object[] {
            resources.GetString("verCombo.Items")});
            resources.ApplyResources(this.verCombo, "verCombo");
            this.verCombo.Name = "verCombo";
            this.toolTipMain.SetToolTip(this.verCombo, resources.GetString("verCombo.ToolTip"));
            this.verCombo.SelectedIndexChanged += new System.EventHandler(this.verCombo_SelectedIndexChanged);
            // 
            // panelAdvanced
            // 
            resources.ApplyResources(this.panelAdvanced, "panelAdvanced");
            this.panelAdvanced.Controls.Add(this.makeGroup);
            this.panelAdvanced.Name = "panelAdvanced";
            // 
            // makeGroup
            // 
            resources.ApplyResources(this.makeGroup, "makeGroup");
            this.makeGroup.Controls.Add(this.groupBox1);
            this.makeGroup.Name = "makeGroup";
            this.makeGroup.TabStop = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkTerm);
            this.groupBox1.Controls.Add(this.checkLog);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.panelSimple);
            this.Name = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedBar)).EndInit();
            this.panelSimple.ResumeLayout(false);
            this.panelSimple.PerformLayout();
            this.panelAdvanced.ResumeLayout(false);
            this.panelAdvanced.PerformLayout();
            this.makeGroup.ResumeLayout(false);
            this.makeGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox outputText;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.NumericUpDown jobNumber;
        private System.Windows.Forms.CheckBox checkDepend;
        private System.Windows.Forms.PictureBox sm64PortLogo;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Label labelMSYS2;
        private System.Windows.Forms.TextBox textMSYS2;
        private System.Windows.Forms.Button buttonMSYS2;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.CheckBox checkTerm;
        private System.Windows.Forms.ProgressBar compileProgress;
        private System.Windows.Forms.PictureBox advancedBar;
        private System.Windows.Forms.Panel panelSimple;
        private System.Windows.Forms.Panel panelAdvanced;
        private System.Windows.Forms.GroupBox makeGroup;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox verCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Button getVersBtn;
    }
}

