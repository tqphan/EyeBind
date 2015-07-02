namespace EyeBind
{
    partial class ProfileCloner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileCloner));
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.profileHotkeyResetButton = new System.Windows.Forms.Button();
            this.profileHotKeyTextBox = new EyeBind.HotKeyTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.profileNameTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.selectNone = new System.Windows.Forms.Button();
            this.selectAll = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(24, 171);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(200, 178);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.profileHotkeyResetButton);
            this.groupBox2.Controls.Add(this.profileHotKeyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(24, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 52);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile Hotkey";
            // 
            // profileHotkeyResetButton
            // 
            this.profileHotkeyResetButton.Location = new System.Drawing.Point(119, 19);
            this.profileHotkeyResetButton.Name = "profileHotkeyResetButton";
            this.profileHotkeyResetButton.Size = new System.Drawing.Size(75, 23);
            this.profileHotkeyResetButton.TabIndex = 1;
            this.profileHotkeyResetButton.Text = "Reset";
            this.profileHotkeyResetButton.UseVisualStyleBackColor = true;
            this.profileHotkeyResetButton.Click += new System.EventHandler(this.profileHotkeyResetButton_Click);
            // 
            // profileHotKeyTextBox
            // 
            this.profileHotKeyTextBox.Location = new System.Drawing.Point(6, 19);
            this.profileHotKeyTextBox.Name = "profileHotKeyTextBox";
            this.profileHotKeyTextBox.SettingKey = System.Windows.Forms.Keys.None;
            this.profileHotKeyTextBox.Size = new System.Drawing.Size(107, 20);
            this.profileHotKeyTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.profileNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Name";
            // 
            // profileNameTextBox
            // 
            this.profileNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.profileNameTextBox.Name = "profileNameTextBox";
            this.profileNameTextBox.Size = new System.Drawing.Size(188, 20);
            this.profileNameTextBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(150, 364);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(24, 364);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // selectNone
            // 
            this.selectNone.Location = new System.Drawing.Point(150, 136);
            this.selectNone.Name = "selectNone";
            this.selectNone.Size = new System.Drawing.Size(75, 23);
            this.selectNone.TabIndex = 7;
            this.selectNone.Text = "Select None";
            this.selectNone.UseVisualStyleBackColor = true;
            this.selectNone.Click += new System.EventHandler(this.selectNone_Click);
            // 
            // selectAll
            // 
            this.selectAll.Location = new System.Drawing.Point(24, 136);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(75, 23);
            this.selectAll.TabIndex = 6;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // ProfileCloner
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(251, 399);
            this.Controls.Add(this.selectNone);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileCloner";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clone Profile";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button profileHotkeyResetButton;
        private HotKeyTextBox profileHotKeyTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox profileNameTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button selectNone;
        private System.Windows.Forms.Button selectAll;
    }
}