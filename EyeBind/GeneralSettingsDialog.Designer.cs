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
            this.deactivationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.activationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.mainWindowTopMostCheckBox = new System.Windows.Forms.CheckBox();
            this.blinkActivationSoundEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // deactivationSoundEnabledCheckBox
            // 
            this.deactivationSoundEnabledCheckBox.AutoSize = true;
            this.deactivationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.DeactivationSoundEnabled;
            this.deactivationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "DeactivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.deactivationSoundEnabledCheckBox.Location = new System.Drawing.Point(29, 122);
            this.deactivationSoundEnabledCheckBox.Name = "deactivationSoundEnabledCheckBox";
            this.deactivationSoundEnabledCheckBox.Size = new System.Drawing.Size(181, 17);
            this.deactivationSoundEnabledCheckBox.TabIndex = 2;
            this.deactivationSoundEnabledCheckBox.Text = "Enable gaze deactivation sound.";
            this.deactivationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // activationSoundEnabledCheckBox
            // 
            this.activationSoundEnabledCheckBox.AutoSize = true;
            this.activationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.ActivationSoundEnabled;
            this.activationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "ActivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.activationSoundEnabledCheckBox.Location = new System.Drawing.Point(29, 99);
            this.activationSoundEnabledCheckBox.Name = "activationSoundEnabledCheckBox";
            this.activationSoundEnabledCheckBox.Size = new System.Drawing.Size(169, 17);
            this.activationSoundEnabledCheckBox.TabIndex = 1;
            this.activationSoundEnabledCheckBox.Text = "Enable gaze activation sound.";
            this.activationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // mainWindowTopMostCheckBox
            // 
            this.mainWindowTopMostCheckBox.AutoSize = true;
            this.mainWindowTopMostCheckBox.Checked = global::EyeBind.Properties.Settings.Default.MainWindowTopMost;
            this.mainWindowTopMostCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "mainWindowTopMost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mainWindowTopMostCheckBox.Location = new System.Drawing.Point(29, 46);
            this.mainWindowTopMostCheckBox.Name = "mainWindowTopMostCheckBox";
            this.mainWindowTopMostCheckBox.Size = new System.Drawing.Size(151, 17);
            this.mainWindowTopMostCheckBox.TabIndex = 0;
            this.mainWindowTopMostCheckBox.Text = "Keep main window on top.";
            this.mainWindowTopMostCheckBox.UseVisualStyleBackColor = true;
            // 
            // blinkActivationSoundEnabledCheckBox
            // 
            this.blinkActivationSoundEnabledCheckBox.AutoSize = true;
            this.blinkActivationSoundEnabledCheckBox.Checked = global::EyeBind.Properties.Settings.Default.BlinkActivationSoundEnabled;
            this.blinkActivationSoundEnabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "BlinkActivationSoundEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.blinkActivationSoundEnabledCheckBox.Location = new System.Drawing.Point(29, 145);
            this.blinkActivationSoundEnabledCheckBox.Name = "blinkActivationSoundEnabledCheckBox";
            this.blinkActivationSoundEnabledCheckBox.Size = new System.Drawing.Size(168, 17);
            this.blinkActivationSoundEnabledCheckBox.TabIndex = 3;
            this.blinkActivationSoundEnabledCheckBox.Text = "Enable blink activation sound.";
            this.blinkActivationSoundEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneralSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 354);
            this.Controls.Add(this.blinkActivationSoundEnabledCheckBox);
            this.Controls.Add(this.deactivationSoundEnabledCheckBox);
            this.Controls.Add(this.activationSoundEnabledCheckBox);
            this.Controls.Add(this.mainWindowTopMostCheckBox);
            this.Name = "GeneralSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox mainWindowTopMostCheckBox;
        private System.Windows.Forms.CheckBox activationSoundEnabledCheckBox;
        private System.Windows.Forms.CheckBox deactivationSoundEnabledCheckBox;
        private System.Windows.Forms.CheckBox blinkActivationSoundEnabledCheckBox;
    }
}