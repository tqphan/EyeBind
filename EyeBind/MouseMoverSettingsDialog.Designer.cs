namespace EyeBind
{
    partial class MouseMoverSettingsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MouseMoverSettingsDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.hotkeyResetButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.followSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.accelerationTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.followRadioButton = new System.Windows.Forms.RadioButton();
            this.fpsRadioButton = new System.Windows.Forms.RadioButton();
            this.warpRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.warpStopDistanceTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.hotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.followSpeedTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accelerationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warpStopDistanceTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.acceptButton);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mouse Mover";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.hotkeyResetButton);
            this.groupBox5.Controls.Add(this.hotKeyTextBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(306, 52);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hotkey";
            // 
            // hotkeyResetButton
            // 
            this.hotkeyResetButton.Location = new System.Drawing.Point(119, 19);
            this.hotkeyResetButton.Name = "hotkeyResetButton";
            this.hotkeyResetButton.Size = new System.Drawing.Size(75, 23);
            this.hotkeyResetButton.TabIndex = 1;
            this.hotkeyResetButton.Text = "Reset";
            this.hotkeyResetButton.UseVisualStyleBackColor = true;
            this.hotkeyResetButton.Click += new System.EventHandler(this.hotkeyResetButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.followSpeedTrackBar);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(6, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 73);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Follow Gaze Point Settings";
            // 
            // followSpeedTrackBar
            // 
            this.followSpeedTrackBar.LargeChange = 1;
            this.followSpeedTrackBar.Location = new System.Drawing.Point(79, 26);
            this.followSpeedTrackBar.Maximum = 50;
            this.followSpeedTrackBar.Minimum = 1;
            this.followSpeedTrackBar.Name = "followSpeedTrackBar";
            this.followSpeedTrackBar.Size = new System.Drawing.Size(221, 45);
            this.followSpeedTrackBar.TabIndex = 5;
            this.followSpeedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.followSpeedTrackBar.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Speed";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(185, 403);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(60, 403);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.accelerationTrackBar);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.speedTrackBar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 91);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "First-Person Shooter Settings";
            // 
            // accelerationTrackBar
            // 
            this.accelerationTrackBar.LargeChange = 1;
            this.accelerationTrackBar.Location = new System.Drawing.Point(79, 56);
            this.accelerationTrackBar.Maximum = 5;
            this.accelerationTrackBar.Minimum = 1;
            this.accelerationTrackBar.Name = "accelerationTrackBar";
            this.accelerationTrackBar.Size = new System.Drawing.Size(221, 45);
            this.accelerationTrackBar.TabIndex = 7;
            this.accelerationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.accelerationTrackBar.Value = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Acceleration";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.LargeChange = 1;
            this.speedTrackBar.Location = new System.Drawing.Point(79, 26);
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(221, 45);
            this.speedTrackBar.TabIndex = 5;
            this.speedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedTrackBar.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Speed";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.followRadioButton);
            this.groupBox2.Controls.Add(this.fpsRadioButton);
            this.groupBox2.Controls.Add(this.warpRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 55);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // followRadioButton
            // 
            this.followRadioButton.AutoSize = true;
            this.followRadioButton.Location = new System.Drawing.Point(63, 19);
            this.followRadioButton.Name = "followRadioButton";
            this.followRadioButton.Size = new System.Drawing.Size(55, 17);
            this.followRadioButton.TabIndex = 2;
            this.followRadioButton.TabStop = true;
            this.followRadioButton.Text = "Follow";
            this.followRadioButton.UseVisualStyleBackColor = true;
            // 
            // fpsRadioButton
            // 
            this.fpsRadioButton.AutoSize = true;
            this.fpsRadioButton.Location = new System.Drawing.Point(124, 19);
            this.fpsRadioButton.Name = "fpsRadioButton";
            this.fpsRadioButton.Size = new System.Drawing.Size(80, 17);
            this.fpsRadioButton.TabIndex = 1;
            this.fpsRadioButton.TabStop = true;
            this.fpsRadioButton.Text = "First-Person";
            this.fpsRadioButton.UseVisualStyleBackColor = true;
            // 
            // warpRadioButton
            // 
            this.warpRadioButton.AutoSize = true;
            this.warpRadioButton.Location = new System.Drawing.Point(6, 19);
            this.warpRadioButton.Name = "warpRadioButton";
            this.warpRadioButton.Size = new System.Drawing.Size(51, 17);
            this.warpRadioButton.TabIndex = 0;
            this.warpRadioButton.TabStop = true;
            this.warpRadioButton.Text = "Warp";
            this.warpRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.warpStopDistanceTrackBar);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(6, 138);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(306, 73);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Warp to Gaze Point Settings";
            // 
            // warpStopDistanceTrackBar
            // 
            this.warpStopDistanceTrackBar.LargeChange = 1;
            this.warpStopDistanceTrackBar.Location = new System.Drawing.Point(79, 26);
            this.warpStopDistanceTrackBar.Maximum = 50;
            this.warpStopDistanceTrackBar.Name = "warpStopDistanceTrackBar";
            this.warpStopDistanceTrackBar.Size = new System.Drawing.Size(221, 45);
            this.warpStopDistanceTrackBar.TabIndex = 5;
            this.warpStopDistanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.warpStopDistanceTrackBar.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stability";
            // 
            // hotKeyTextBox
            // 
            this.hotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.hotKeyTextBox.Name = "hotKeyTextBox";
            this.hotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.hotKeyTextBox.Size = new System.Drawing.Size(107, 20);
            this.hotKeyTextBox.TabIndex = 0;
            // 
            // MouseMoverSettingsDialog
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(342, 453);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MouseMoverSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mouse Mover Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.followSpeedTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accelerationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warpStopDistanceTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton fpsRadioButton;
        private System.Windows.Forms.RadioButton warpRadioButton;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.TrackBar accelerationTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar followSpeedTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton followRadioButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button hotkeyResetButton;
        private HotKeyTextBox hotKeyTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TrackBar warpStopDistanceTrackBar;
        private System.Windows.Forms.Label label3;
    }
}