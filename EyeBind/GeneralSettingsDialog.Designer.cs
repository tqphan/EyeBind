namespace EyeBind
{
    partial class GeneralSettingsDialog
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.mainWindowTopMostCheckBox = new System.Windows.Forms.CheckBox();
            this.soundsTabPage = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.globalSoundsEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.activationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.blinkActivationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.deactivationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeysTabPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toggleGazeMarkerHotKeyResetButton = new System.Windows.Forms.Button();
            this.toggleGazeMarkerHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.continuousMouseMoveHotKeyResetButton = new System.Windows.Forms.Button();
            this.toggleContinuousMouseMoveHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toggleSoundsHotKeyResetButton = new System.Windows.Forms.Button();
            this.toggleSoundsHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toggleKeyboardSimulationResetButton = new System.Windows.Forms.Button();
            this.toggleKeyboardSimulationHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moveMouseHotKeyResetButton = new System.Windows.Forms.Button();
            this.moveMouseHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.tabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.soundsTabPage.SuspendLayout();
            this.hotkeysTabPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Controls.Add(this.soundsTabPage);
            this.tabControl.Controls.Add(this.hotkeysTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(289, 385);
            this.tabControl.TabIndex = 4;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.mainWindowTopMostCheckBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(281, 359);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // mainWindowTopMostCheckBox
            // 
            this.mainWindowTopMostCheckBox.AutoSize = true;
            this.mainWindowTopMostCheckBox.Checked = global::EyeBind.Properties.Settings.Default.MainWindowTopMost;
            this.mainWindowTopMostCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "mainWindowTopMost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mainWindowTopMostCheckBox.Location = new System.Drawing.Point(8, 35);
            this.mainWindowTopMostCheckBox.Name = "mainWindowTopMostCheckBox";
            this.mainWindowTopMostCheckBox.Size = new System.Drawing.Size(151, 17);
            this.mainWindowTopMostCheckBox.TabIndex = 0;
            this.mainWindowTopMostCheckBox.Text = "Keep main window on top.";
            this.mainWindowTopMostCheckBox.UseVisualStyleBackColor = true;
            // 
            // soundsTabPage
            // 
            this.soundsTabPage.Controls.Add(this.checkBox1);
            this.soundsTabPage.Controls.Add(this.checkBox2);
            this.soundsTabPage.Controls.Add(this.globalSoundsEnableCheckBox);
            this.soundsTabPage.Controls.Add(this.activationSoundEnabledCheckBox);
            this.soundsTabPage.Controls.Add(this.blinkActivationSoundEnabledCheckBox);
            this.soundsTabPage.Controls.Add(this.deactivationSoundEnabledCheckBox);
            this.soundsTabPage.Location = new System.Drawing.Point(4, 22);
            this.soundsTabPage.Name = "soundsTabPage";
            this.soundsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.soundsTabPage.Size = new System.Drawing.Size(281, 359);
            this.soundsTabPage.TabIndex = 1;
            this.soundsTabPage.Text = "Sounds";
            this.soundsTabPage.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::EyeBind.Properties.Settings.Default.GazeEnterSoundEnabled;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "GazeEnterSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(23, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Enable gaze enter sound.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::EyeBind.Properties.Settings.Default.GazeExitSoundEnabled;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "GazeExitSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(23, 79);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(139, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Enable gaze exit sound.";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // globalSoundsEnableCheckBox
            // 
            this.globalSoundsEnableCheckBox.AutoSize = true;
            this.globalSoundsEnableCheckBox.Checked = global::EyeBind.Properties.Settings.Default.GlobalSoundEnabled;
            this.globalSoundsEnableCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "GlobalSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.globalSoundsEnableCheckBox.Location = new System.Drawing.Point(8, 35);
            this.globalSoundsEnableCheckBox.Name = "globalSoundsEnableCheckBox";
            this.globalSoundsEnableCheckBox.Size = new System.Drawing.Size(96, 17);
            this.globalSoundsEnableCheckBox.TabIndex = 4;
            this.globalSoundsEnableCheckBox.Text = "Enable sounds";
            this.globalSoundsEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // activationSoundEnabledCheckBox
            // 
            this.activationSoundEnabledCheckBox.AutoSize = true;
            this.activationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.ActivationSoundEnabled;
            this.activationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "ActivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.activationSoundEnabledCheckBox.Location = new System.Drawing.Point(23, 102);
            this.activationSoundEnabledCheckBox.Name = "activationSoundEnabledCheckBox";
            this.activationSoundEnabledCheckBox.Size = new System.Drawing.Size(169, 17);
            this.activationSoundEnabledCheckBox.TabIndex = 1;
            this.activationSoundEnabledCheckBox.Text = "Enable gaze activation sound.";
            this.activationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // blinkActivationSoundEnabledCheckBox
            // 
            this.blinkActivationSoundEnabledCheckBox.AutoSize = true;
            this.blinkActivationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.BlinkActivationSoundEnabled;
            this.blinkActivationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "BlinkActivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.blinkActivationSoundEnabledCheckBox.Location = new System.Drawing.Point(23, 148);
            this.blinkActivationSoundEnabledCheckBox.Name = "blinkActivationSoundEnabledCheckBox";
            this.blinkActivationSoundEnabledCheckBox.Size = new System.Drawing.Size(168, 17);
            this.blinkActivationSoundEnabledCheckBox.TabIndex = 3;
            this.blinkActivationSoundEnabledCheckBox.Text = "Enable blink activation sound.";
            this.blinkActivationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // deactivationSoundEnabledCheckBox
            // 
            this.deactivationSoundEnabledCheckBox.AutoSize = true;
            this.deactivationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.DeactivationSoundEnabled;
            this.deactivationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "DeactivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deactivationSoundEnabledCheckBox.Location = new System.Drawing.Point(23, 125);
            this.deactivationSoundEnabledCheckBox.Name = "deactivationSoundEnabledCheckBox";
            this.deactivationSoundEnabledCheckBox.Size = new System.Drawing.Size(181, 17);
            this.deactivationSoundEnabledCheckBox.TabIndex = 2;
            this.deactivationSoundEnabledCheckBox.Text = "Enable gaze deactivation sound.";
            this.deactivationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // hotkeysTabPage
            // 
            this.hotkeysTabPage.Controls.Add(this.groupBox5);
            this.hotkeysTabPage.Controls.Add(this.groupBox4);
            this.hotkeysTabPage.Controls.Add(this.groupBox3);
            this.hotkeysTabPage.Controls.Add(this.groupBox2);
            this.hotkeysTabPage.Controls.Add(this.groupBox1);
            this.hotkeysTabPage.Location = new System.Drawing.Point(4, 22);
            this.hotkeysTabPage.Name = "hotkeysTabPage";
            this.hotkeysTabPage.Size = new System.Drawing.Size(281, 359);
            this.hotkeysTabPage.TabIndex = 2;
            this.hotkeysTabPage.Text = "Hotkeys";
            this.hotkeysTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.toggleGazeMarkerHotKeyResetButton);
            this.groupBox5.Controls.Add(this.toggleGazeMarkerHotKeyTextBox);
            this.groupBox5.Location = new System.Drawing.Point(8, 273);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(265, 54);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Toggle gaze marker on/off hotkey";
            // 
            // toggleGazeMarkerHotKeyResetButton
            // 
            this.toggleGazeMarkerHotKeyResetButton.Location = new System.Drawing.Point(199, 19);
            this.toggleGazeMarkerHotKeyResetButton.Name = "toggleGazeMarkerHotKeyResetButton";
            this.toggleGazeMarkerHotKeyResetButton.Size = new System.Drawing.Size(60, 20);
            this.toggleGazeMarkerHotKeyResetButton.TabIndex = 1;
            this.toggleGazeMarkerHotKeyResetButton.Text = "Reset";
            this.toggleGazeMarkerHotKeyResetButton.UseVisualStyleBackColor = true;
            this.toggleGazeMarkerHotKeyResetButton.Click += new System.EventHandler(this.toggleGazeMarkerHotKeyResetButton_Click);
            // 
            // toggleGazeMarkerHotKeyTextBox
            // 
            this.toggleGazeMarkerHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.toggleGazeMarkerHotKeyTextBox.Name = "toggleGazeMarkerHotKeyTextBox";
            this.toggleGazeMarkerHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.toggleGazeMarkerHotKeyTextBox.Size = new System.Drawing.Size(147, 20);
            this.toggleGazeMarkerHotKeyTextBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.continuousMouseMoveHotKeyResetButton);
            this.groupBox4.Controls.Add(this.toggleContinuousMouseMoveHotKeyTextBox);
            this.groupBox4.Location = new System.Drawing.Point(8, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 54);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Toggle continuous mouse move on/off hotkey";
            // 
            // continuousMouseMoveHotKeyResetButton
            // 
            this.continuousMouseMoveHotKeyResetButton.Location = new System.Drawing.Point(199, 19);
            this.continuousMouseMoveHotKeyResetButton.Name = "continuousMouseMoveHotKeyResetButton";
            this.continuousMouseMoveHotKeyResetButton.Size = new System.Drawing.Size(60, 20);
            this.continuousMouseMoveHotKeyResetButton.TabIndex = 1;
            this.continuousMouseMoveHotKeyResetButton.Text = "Reset";
            this.continuousMouseMoveHotKeyResetButton.UseVisualStyleBackColor = true;
            this.continuousMouseMoveHotKeyResetButton.Click += new System.EventHandler(this.continuousMouseMoveHotKeyResetButton_Click);
            // 
            // toggleContinuousMouseMoveHotKeyTextBox
            // 
            this.toggleContinuousMouseMoveHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.toggleContinuousMouseMoveHotKeyTextBox.Name = "toggleContinuousMouseMoveHotKeyTextBox";
            this.toggleContinuousMouseMoveHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.toggleContinuousMouseMoveHotKeyTextBox.Size = new System.Drawing.Size(147, 20);
            this.toggleContinuousMouseMoveHotKeyTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.toggleSoundsHotKeyResetButton);
            this.groupBox3.Controls.Add(this.toggleSoundsHotKeyTextBox);
            this.groupBox3.Location = new System.Drawing.Point(8, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Toggle sounds on/off hotkey";
            // 
            // toggleSoundsHotKeyResetButton
            // 
            this.toggleSoundsHotKeyResetButton.Location = new System.Drawing.Point(199, 19);
            this.toggleSoundsHotKeyResetButton.Name = "toggleSoundsHotKeyResetButton";
            this.toggleSoundsHotKeyResetButton.Size = new System.Drawing.Size(60, 20);
            this.toggleSoundsHotKeyResetButton.TabIndex = 1;
            this.toggleSoundsHotKeyResetButton.Text = "Reset";
            this.toggleSoundsHotKeyResetButton.UseVisualStyleBackColor = true;
            this.toggleSoundsHotKeyResetButton.Click += new System.EventHandler(this.toggleSoundsHotKeyResetButton_Click);
            // 
            // toggleSoundsHotKeyTextBox
            // 
            this.toggleSoundsHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.toggleSoundsHotKeyTextBox.Name = "toggleSoundsHotKeyTextBox";
            this.toggleSoundsHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.toggleSoundsHotKeyTextBox.Size = new System.Drawing.Size(147, 20);
            this.toggleSoundsHotKeyTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toggleKeyboardSimulationResetButton);
            this.groupBox2.Controls.Add(this.toggleKeyboardSimulationHotKeyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Toggle keyboard simulation on/off hotkey";
            // 
            // toggleKeyboardSimulationResetButton
            // 
            this.toggleKeyboardSimulationResetButton.Location = new System.Drawing.Point(199, 19);
            this.toggleKeyboardSimulationResetButton.Name = "toggleKeyboardSimulationResetButton";
            this.toggleKeyboardSimulationResetButton.Size = new System.Drawing.Size(60, 20);
            this.toggleKeyboardSimulationResetButton.TabIndex = 1;
            this.toggleKeyboardSimulationResetButton.Text = "Reset";
            this.toggleKeyboardSimulationResetButton.UseVisualStyleBackColor = true;
            this.toggleKeyboardSimulationResetButton.Click += new System.EventHandler(this.toggleKeyboardSimulationResetButton_Click);
            // 
            // toggleKeyboardSimulationHotKeyTextBox
            // 
            this.toggleKeyboardSimulationHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.toggleKeyboardSimulationHotKeyTextBox.Name = "toggleKeyboardSimulationHotKeyTextBox";
            this.toggleKeyboardSimulationHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.toggleKeyboardSimulationHotKeyTextBox.Size = new System.Drawing.Size(147, 20);
            this.toggleKeyboardSimulationHotKeyTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moveMouseHotKeyResetButton);
            this.groupBox1.Controls.Add(this.moveMouseHotKeyTextBox);
            this.groupBox1.Location = new System.Drawing.Point(8, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move mouse pointer to gaze point hotkey";
            // 
            // moveMouseHotKeyResetButton
            // 
            this.moveMouseHotKeyResetButton.Location = new System.Drawing.Point(199, 19);
            this.moveMouseHotKeyResetButton.Name = "moveMouseHotKeyResetButton";
            this.moveMouseHotKeyResetButton.Size = new System.Drawing.Size(60, 20);
            this.moveMouseHotKeyResetButton.TabIndex = 1;
            this.moveMouseHotKeyResetButton.Text = "Reset";
            this.moveMouseHotKeyResetButton.UseVisualStyleBackColor = true;
            this.moveMouseHotKeyResetButton.Click += new System.EventHandler(this.moveMouseHotKeyResetButton_Click);
            // 
            // moveMouseHotKeyTextBox
            // 
            this.moveMouseHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.moveMouseHotKeyTextBox.Name = "moveMouseHotKeyTextBox";
            this.moveMouseHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.moveMouseHotKeyTextBox.Size = new System.Drawing.Size(147, 20);
            this.moveMouseHotKeyTextBox.TabIndex = 0;
            // 
            // GeneralSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 385);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Settings";
            this.tabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.soundsTabPage.ResumeLayout(false);
            this.soundsTabPage.PerformLayout();
            this.hotkeysTabPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox mainWindowTopMostCheckBox;
        private System.Windows.Forms.CheckBox activationSoundEnabledCheckBox;
        private System.Windows.Forms.CheckBox deactivationSoundEnabledCheckBox;
        private System.Windows.Forms.CheckBox blinkActivationSoundEnabledCheckBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage soundsTabPage;
        private System.Windows.Forms.TabPage hotkeysTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button moveMouseHotKeyResetButton;
        private HotKeyTextBox moveMouseHotKeyTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button toggleSoundsHotKeyResetButton;
        private HotKeyTextBox toggleSoundsHotKeyTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button toggleKeyboardSimulationResetButton;
        private HotKeyTextBox toggleKeyboardSimulationHotKeyTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button continuousMouseMoveHotKeyResetButton;
        private HotKeyTextBox toggleContinuousMouseMoveHotKeyTextBox;
        private System.Windows.Forms.CheckBox globalSoundsEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button toggleGazeMarkerHotKeyResetButton;
        private HotKeyTextBox toggleGazeMarkerHotKeyTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}