namespace EyeBind
{
    partial class BlinkConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlinkConfig));
            this.blinktabControl = new System.Windows.Forms.TabControl();
            this.leftEyeTabPage = new System.Windows.Forms.TabPage();
            this.leftEyeBinkEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.leftEyeActivationDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.leftEyeClearInputsButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rightEyeTabPage = new System.Windows.Forms.TabPage();
            this.rightEyeBinkEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rightEyeActivationDelayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rightEyeClearInputsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.leftEyeKeyRecorderDataGridView = new EyeBind.KeyRecorderDataGridView();
            this.leftEyeKeyRecorderCheckBox = new EyeBind.KeyRecorderCheckBox();
            this.rightEyeKeyRecorderDataGridView = new EyeBind.KeyRecorderDataGridView();
            this.rightEyeKeyRecorderCheckBox = new EyeBind.KeyRecorderCheckBox();
            this.blinktabControl.SuspendLayout();
            this.leftEyeTabPage.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEyeActivationDelayNumericUpDown)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.rightEyeTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightEyeActivationDelayNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEyeKeyRecorderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEyeKeyRecorderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // blinktabControl
            // 
            this.blinktabControl.Controls.Add(this.leftEyeTabPage);
            this.blinktabControl.Controls.Add(this.rightEyeTabPage);
            this.blinktabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blinktabControl.Location = new System.Drawing.Point(0, 0);
            this.blinktabControl.Name = "blinktabControl";
            this.blinktabControl.SelectedIndex = 0;
            this.blinktabControl.Size = new System.Drawing.Size(452, 542);
            this.blinktabControl.TabIndex = 0;
            // 
            // leftEyeTabPage
            // 
            this.leftEyeTabPage.Controls.Add(this.leftEyeBinkEnabledCheckBox);
            this.leftEyeTabPage.Controls.Add(this.label7);
            this.leftEyeTabPage.Controls.Add(this.groupBox11);
            this.leftEyeTabPage.Controls.Add(this.leftEyeClearInputsButton);
            this.leftEyeTabPage.Controls.Add(this.groupBox7);
            this.leftEyeTabPage.Controls.Add(this.leftEyeKeyRecorderCheckBox);
            this.leftEyeTabPage.Location = new System.Drawing.Point(4, 22);
            this.leftEyeTabPage.Name = "leftEyeTabPage";
            this.leftEyeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.leftEyeTabPage.Size = new System.Drawing.Size(444, 516);
            this.leftEyeTabPage.TabIndex = 0;
            this.leftEyeTabPage.Text = "Left Eye";
            this.leftEyeTabPage.UseVisualStyleBackColor = true;
            // 
            // leftEyeBinkEnabledCheckBox
            // 
            this.leftEyeBinkEnabledCheckBox.AutoSize = true;
            this.leftEyeBinkEnabledCheckBox.Location = new System.Drawing.Point(24, 16);
            this.leftEyeBinkEnabledCheckBox.Name = "leftEyeBinkEnabledCheckBox";
            this.leftEyeBinkEnabledCheckBox.Size = new System.Drawing.Size(127, 17);
            this.leftEyeBinkEnabledCheckBox.TabIndex = 10;
            this.leftEyeBinkEnabledCheckBox.Text = "Enable Left Eye Blink";
            this.leftEyeBinkEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "All keyboard simulation are paused when editing.";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.leftEyeActivationDelayNumericUpDown);
            this.groupBox11.Location = new System.Drawing.Point(24, 430);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(175, 68);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Activation Delay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Miliseconds";
            // 
            // leftEyeActivationDelayNumericUpDown
            // 
            this.leftEyeActivationDelayNumericUpDown.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.leftEyeActivationDelayNumericUpDown.Location = new System.Drawing.Point(6, 25);
            this.leftEyeActivationDelayNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.leftEyeActivationDelayNumericUpDown.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.leftEyeActivationDelayNumericUpDown.Name = "leftEyeActivationDelayNumericUpDown";
            this.leftEyeActivationDelayNumericUpDown.ReadOnly = true;
            this.leftEyeActivationDelayNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.leftEyeActivationDelayNumericUpDown.TabIndex = 4;
            this.leftEyeActivationDelayNumericUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // leftEyeClearInputsButton
            // 
            this.leftEyeClearInputsButton.Location = new System.Drawing.Point(246, 58);
            this.leftEyeClearInputsButton.Name = "leftEyeClearInputsButton";
            this.leftEyeClearInputsButton.Size = new System.Drawing.Size(175, 30);
            this.leftEyeClearInputsButton.TabIndex = 7;
            this.leftEyeClearInputsButton.Text = "Clear Inputs";
            this.leftEyeClearInputsButton.UseVisualStyleBackColor = true;
            this.leftEyeClearInputsButton.Click += new System.EventHandler(this.leftEyeClearInputsButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.leftEyeKeyRecorderDataGridView);
            this.groupBox7.Location = new System.Drawing.Point(21, 109);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(400, 300);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Left Eye Blink Inputs";
            // 
            // rightEyeTabPage
            // 
            this.rightEyeTabPage.Controls.Add(this.rightEyeBinkEnabledCheckBox);
            this.rightEyeTabPage.Controls.Add(this.label1);
            this.rightEyeTabPage.Controls.Add(this.groupBox1);
            this.rightEyeTabPage.Controls.Add(this.rightEyeClearInputsButton);
            this.rightEyeTabPage.Controls.Add(this.groupBox2);
            this.rightEyeTabPage.Controls.Add(this.rightEyeKeyRecorderCheckBox);
            this.rightEyeTabPage.Location = new System.Drawing.Point(4, 22);
            this.rightEyeTabPage.Name = "rightEyeTabPage";
            this.rightEyeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.rightEyeTabPage.Size = new System.Drawing.Size(444, 516);
            this.rightEyeTabPage.TabIndex = 1;
            this.rightEyeTabPage.Text = "Right Eye";
            this.rightEyeTabPage.UseVisualStyleBackColor = true;
            // 
            // rightEyeBinkEnabledCheckBox
            // 
            this.rightEyeBinkEnabledCheckBox.AutoSize = true;
            this.rightEyeBinkEnabledCheckBox.Location = new System.Drawing.Point(24, 16);
            this.rightEyeBinkEnabledCheckBox.Name = "rightEyeBinkEnabledCheckBox";
            this.rightEyeBinkEnabledCheckBox.Size = new System.Drawing.Size(134, 17);
            this.rightEyeBinkEnabledCheckBox.TabIndex = 10;
            this.rightEyeBinkEnabledCheckBox.Text = "Enable Right Eye Blink";
            this.rightEyeBinkEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "All keyboard simulation are paused when editing.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rightEyeActivationDelayNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(24, 430);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 68);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activation Delay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Miliseconds";
            // 
            // rightEyeActivationDelayNumericUpDown
            // 
            this.rightEyeActivationDelayNumericUpDown.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.rightEyeActivationDelayNumericUpDown.Location = new System.Drawing.Point(6, 25);
            this.rightEyeActivationDelayNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.rightEyeActivationDelayNumericUpDown.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.rightEyeActivationDelayNumericUpDown.Name = "rightEyeActivationDelayNumericUpDown";
            this.rightEyeActivationDelayNumericUpDown.ReadOnly = true;
            this.rightEyeActivationDelayNumericUpDown.Size = new System.Drawing.Size(66, 20);
            this.rightEyeActivationDelayNumericUpDown.TabIndex = 4;
            this.rightEyeActivationDelayNumericUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // rightEyeClearInputsButton
            // 
            this.rightEyeClearInputsButton.Location = new System.Drawing.Point(246, 58);
            this.rightEyeClearInputsButton.Name = "rightEyeClearInputsButton";
            this.rightEyeClearInputsButton.Size = new System.Drawing.Size(175, 30);
            this.rightEyeClearInputsButton.TabIndex = 7;
            this.rightEyeClearInputsButton.Text = "Clear Inputs";
            this.rightEyeClearInputsButton.UseVisualStyleBackColor = true;
            this.rightEyeClearInputsButton.Click += new System.EventHandler(this.rightEyeClearInputsButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rightEyeKeyRecorderDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(21, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 300);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Right Eye Blink Inputs";
            // 
            // leftEyeKeyRecorderDataGridView
            // 
            this.leftEyeKeyRecorderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftEyeKeyRecorderDataGridView.ColumnHeadersVisible = false;
            this.leftEyeKeyRecorderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftEyeKeyRecorderDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.leftEyeKeyRecorderDataGridView.Location = new System.Drawing.Point(3, 16);
            this.leftEyeKeyRecorderDataGridView.Name = "leftEyeKeyRecorderDataGridView";
            this.leftEyeKeyRecorderDataGridView.RowHeadersVisible = false;
            this.leftEyeKeyRecorderDataGridView.Size = new System.Drawing.Size(394, 281);
            this.leftEyeKeyRecorderDataGridView.TabIndex = 0;
            // 
            // leftEyeKeyRecorderCheckBox
            // 
            this.leftEyeKeyRecorderCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.leftEyeKeyRecorderCheckBox.Location = new System.Drawing.Point(24, 58);
            this.leftEyeKeyRecorderCheckBox.Name = "leftEyeKeyRecorderCheckBox";
            this.leftEyeKeyRecorderCheckBox.Size = new System.Drawing.Size(175, 30);
            this.leftEyeKeyRecorderCheckBox.TabIndex = 6;
            this.leftEyeKeyRecorderCheckBox.Text = "⚫ Start Recording Key";
            this.leftEyeKeyRecorderCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.leftEyeKeyRecorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // rightEyeKeyRecorderDataGridView
            // 
            this.rightEyeKeyRecorderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightEyeKeyRecorderDataGridView.ColumnHeadersVisible = false;
            this.rightEyeKeyRecorderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightEyeKeyRecorderDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.rightEyeKeyRecorderDataGridView.Location = new System.Drawing.Point(3, 16);
            this.rightEyeKeyRecorderDataGridView.Name = "rightEyeKeyRecorderDataGridView";
            this.rightEyeKeyRecorderDataGridView.RowHeadersVisible = false;
            this.rightEyeKeyRecorderDataGridView.Size = new System.Drawing.Size(394, 281);
            this.rightEyeKeyRecorderDataGridView.TabIndex = 0;
            // 
            // rightEyeKeyRecorderCheckBox
            // 
            this.rightEyeKeyRecorderCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rightEyeKeyRecorderCheckBox.Location = new System.Drawing.Point(24, 58);
            this.rightEyeKeyRecorderCheckBox.Name = "rightEyeKeyRecorderCheckBox";
            this.rightEyeKeyRecorderCheckBox.Size = new System.Drawing.Size(175, 30);
            this.rightEyeKeyRecorderCheckBox.TabIndex = 6;
            this.rightEyeKeyRecorderCheckBox.Text = "⚫ Start Recording Key";
            this.rightEyeKeyRecorderCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rightEyeKeyRecorderCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlinkConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 542);
            this.Controls.Add(this.blinktabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BlinkConfig";
            this.ShowInTaskbar = false;
            this.Text = "BlinkConfig";
            this.blinktabControl.ResumeLayout(false);
            this.leftEyeTabPage.ResumeLayout(false);
            this.leftEyeTabPage.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftEyeActivationDelayNumericUpDown)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.rightEyeTabPage.ResumeLayout(false);
            this.rightEyeTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightEyeActivationDelayNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftEyeKeyRecorderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightEyeKeyRecorderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl blinktabControl;
        private System.Windows.Forms.TabPage leftEyeTabPage;
        private System.Windows.Forms.TabPage rightEyeTabPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown leftEyeActivationDelayNumericUpDown;
        private System.Windows.Forms.Button leftEyeClearInputsButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private KeyRecorderDataGridView leftEyeKeyRecorderDataGridView;
        private KeyRecorderCheckBox leftEyeKeyRecorderCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown rightEyeActivationDelayNumericUpDown;
        private System.Windows.Forms.Button rightEyeClearInputsButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private KeyRecorderDataGridView rightEyeKeyRecorderDataGridView;
        private KeyRecorderCheckBox rightEyeKeyRecorderCheckBox;
        private System.Windows.Forms.CheckBox leftEyeBinkEnabledCheckBox;
        private System.Windows.Forms.CheckBox rightEyeBinkEnabledCheckBox;

    }
}