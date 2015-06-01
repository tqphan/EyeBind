namespace EyeBind
{
    partial class EyeBindMainForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.profilesComboBox = new EyeBind.ProfilesComboBox();
            this.gazeRegionsListBox = new EyeBind.GazeRegionsListBox();
            this.newProfileButton = new System.Windows.Forms.Button();
            this.newGazeRegionButton = new System.Windows.Forms.Button();
            this.deleteGazeRegionButton = new System.Windows.Forms.Button();
            this.editGazeRegionButton = new System.Windows.Forms.Button();
            this.cloneGazeRegionButton = new System.Windows.Forms.Button();
            this.gazeMarkerCheckBox = new System.Windows.Forms.CheckBox();
            this.pauseSimulationCheckBox = new System.Windows.Forms.CheckBox();
            this.hideGazeRegionsButton = new System.Windows.Forms.Button();
            this.generalSettingsButton = new System.Windows.Forms.Button();
            this.blinkButton = new System.Windows.Forms.Button();
            this.showGazeRegionsButton = new System.Windows.Forms.Button();
            this.mouseMoverButton = new System.Windows.Forms.Button();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.cloneProfileButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.deleteProfileButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.profilesComboBox, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.gazeRegionsListBox, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.newProfileButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.newGazeRegionButton, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.deleteGazeRegionButton, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.editGazeRegionButton, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.cloneGazeRegionButton, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.gazeMarkerCheckBox, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.pauseSimulationCheckBox, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.hideGazeRegionsButton, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.generalSettingsButton, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.blinkButton, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.showGazeRegionsButton, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.mouseMoverButton, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.editProfileButton, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.cloneProfileButton, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 11;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(234, 448);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteProfileButton.Location = new System.Drawing.Point(117, 0);
            this.deleteProfileButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(117, 32);
            this.deleteProfileButton.TabIndex = 3;
            this.deleteProfileButton.Text = "Delete Profile";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.deleteProfileButton_Click);
            // 
            // profilesComboBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.profilesComboBox, 2);
            this.profilesComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profilesComboBox.FormattingEnabled = true;
            this.profilesComboBox.Location = new System.Drawing.Point(3, 67);
            this.profilesComboBox.Name = "profilesComboBox";
            this.profilesComboBox.Size = new System.Drawing.Size(228, 21);
            this.profilesComboBox.TabIndex = 0;
            // 
            // gazeRegionsListBox
            // 
            this.tableLayoutPanel.SetColumnSpan(this.gazeRegionsListBox, 2);
            this.gazeRegionsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gazeRegionsListBox.FormattingEnabled = true;
            this.gazeRegionsListBox.IntegralHeight = false;
            this.gazeRegionsListBox.Location = new System.Drawing.Point(3, 94);
            this.gazeRegionsListBox.Name = "gazeRegionsListBox";
            this.gazeRegionsListBox.Size = new System.Drawing.Size(228, 141);
            this.gazeRegionsListBox.TabIndex = 1;
            // 
            // newProfileButton
            // 
            this.newProfileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProfileButton.Location = new System.Drawing.Point(0, 0);
            this.newProfileButton.Margin = new System.Windows.Forms.Padding(0);
            this.newProfileButton.Name = "newProfileButton";
            this.newProfileButton.Size = new System.Drawing.Size(117, 32);
            this.newProfileButton.TabIndex = 2;
            this.newProfileButton.Text = "New Profile";
            this.newProfileButton.UseVisualStyleBackColor = true;
            this.newProfileButton.Click += new System.EventHandler(this.newProfileButton_Click);
            // 
            // newGazeRegionButton
            // 
            this.newGazeRegionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newGazeRegionButton.Location = new System.Drawing.Point(0, 238);
            this.newGazeRegionButton.Margin = new System.Windows.Forms.Padding(0);
            this.newGazeRegionButton.Name = "newGazeRegionButton";
            this.newGazeRegionButton.Size = new System.Drawing.Size(117, 32);
            this.newGazeRegionButton.TabIndex = 4;
            this.newGazeRegionButton.Text = "New Gaze Region";
            this.newGazeRegionButton.UseVisualStyleBackColor = true;
            this.newGazeRegionButton.Click += new System.EventHandler(this.newGazeRegionButton_Click);
            // 
            // deleteGazeRegionButton
            // 
            this.deleteGazeRegionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteGazeRegionButton.Location = new System.Drawing.Point(117, 238);
            this.deleteGazeRegionButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteGazeRegionButton.Name = "deleteGazeRegionButton";
            this.deleteGazeRegionButton.Size = new System.Drawing.Size(117, 32);
            this.deleteGazeRegionButton.TabIndex = 5;
            this.deleteGazeRegionButton.Text = "Delete Gaze Region";
            this.deleteGazeRegionButton.UseVisualStyleBackColor = true;
            this.deleteGazeRegionButton.Click += new System.EventHandler(this.deleteGazeRegionButton_Click);
            // 
            // editGazeRegionButton
            // 
            this.editGazeRegionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGazeRegionButton.Location = new System.Drawing.Point(0, 270);
            this.editGazeRegionButton.Margin = new System.Windows.Forms.Padding(0);
            this.editGazeRegionButton.Name = "editGazeRegionButton";
            this.editGazeRegionButton.Size = new System.Drawing.Size(117, 32);
            this.editGazeRegionButton.TabIndex = 6;
            this.editGazeRegionButton.Text = "Edit Gaze Region";
            this.editGazeRegionButton.UseVisualStyleBackColor = true;
            this.editGazeRegionButton.Click += new System.EventHandler(this.editGazeRegionButton_Click);
            // 
            // cloneGazeRegionButton
            // 
            this.cloneGazeRegionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloneGazeRegionButton.Location = new System.Drawing.Point(117, 270);
            this.cloneGazeRegionButton.Margin = new System.Windows.Forms.Padding(0);
            this.cloneGazeRegionButton.Name = "cloneGazeRegionButton";
            this.cloneGazeRegionButton.Size = new System.Drawing.Size(117, 32);
            this.cloneGazeRegionButton.TabIndex = 7;
            this.cloneGazeRegionButton.Text = "Clone Gaze Region";
            this.cloneGazeRegionButton.UseVisualStyleBackColor = true;
            this.cloneGazeRegionButton.Click += new System.EventHandler(this.cloneGazeRegionButton_Click);
            // 
            // gazeMarkerCheckBox
            // 
            this.gazeMarkerCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.gazeMarkerCheckBox.AutoSize = true;
            this.gazeMarkerCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gazeMarkerCheckBox.Location = new System.Drawing.Point(117, 344);
            this.gazeMarkerCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.gazeMarkerCheckBox.Name = "gazeMarkerCheckBox";
            this.gazeMarkerCheckBox.Size = new System.Drawing.Size(117, 32);
            this.gazeMarkerCheckBox.TabIndex = 8;
            this.gazeMarkerCheckBox.Text = "Gaze Marker";
            this.gazeMarkerCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gazeMarkerCheckBox.UseVisualStyleBackColor = true;
            this.gazeMarkerCheckBox.CheckedChanged += new System.EventHandler(this.gazeMarkerCheckBox_CheckedChanged);
            // 
            // pauseSimulationCheckBox
            // 
            this.pauseSimulationCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.pauseSimulationCheckBox.AutoSize = true;
            this.pauseSimulationCheckBox.Checked = global::EyeBind.Properties.Settings.Default.InputSimulationPaused;
            this.pauseSimulationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::EyeBind.Properties.Settings.Default, "InputSimulationPaused", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pauseSimulationCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pauseSimulationCheckBox.Location = new System.Drawing.Point(0, 344);
            this.pauseSimulationCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.pauseSimulationCheckBox.Name = "pauseSimulationCheckBox";
            this.pauseSimulationCheckBox.Size = new System.Drawing.Size(117, 32);
            this.pauseSimulationCheckBox.TabIndex = 9;
            this.pauseSimulationCheckBox.Text = "Pause Simulation";
            this.pauseSimulationCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pauseSimulationCheckBox.UseVisualStyleBackColor = true;
            this.pauseSimulationCheckBox.CheckedChanged += new System.EventHandler(this.pauseSimulationCheckBox_CheckedChanged);
            // 
            // hideGazeRegionsButton
            // 
            this.hideGazeRegionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hideGazeRegionsButton.Location = new System.Drawing.Point(0, 302);
            this.hideGazeRegionsButton.Margin = new System.Windows.Forms.Padding(0);
            this.hideGazeRegionsButton.Name = "hideGazeRegionsButton";
            this.hideGazeRegionsButton.Size = new System.Drawing.Size(117, 32);
            this.hideGazeRegionsButton.TabIndex = 10;
            this.hideGazeRegionsButton.Text = "Hide Gaze Regions";
            this.hideGazeRegionsButton.UseVisualStyleBackColor = true;
            this.hideGazeRegionsButton.Click += new System.EventHandler(this.hideGazeRegionsButton_Click);
            // 
            // generalSettingsButton
            // 
            this.tableLayoutPanel.SetColumnSpan(this.generalSettingsButton, 2);
            this.generalSettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalSettingsButton.Location = new System.Drawing.Point(0, 408);
            this.generalSettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.generalSettingsButton.Name = "generalSettingsButton";
            this.generalSettingsButton.Size = new System.Drawing.Size(234, 40);
            this.generalSettingsButton.TabIndex = 11;
            this.generalSettingsButton.Text = "General Settings";
            this.generalSettingsButton.UseVisualStyleBackColor = true;
            this.generalSettingsButton.Click += new System.EventHandler(this.generalSettingsButton_Click);
            // 
            // blinkButton
            // 
            this.blinkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blinkButton.Location = new System.Drawing.Point(0, 376);
            this.blinkButton.Margin = new System.Windows.Forms.Padding(0);
            this.blinkButton.Name = "blinkButton";
            this.blinkButton.Size = new System.Drawing.Size(117, 32);
            this.blinkButton.TabIndex = 12;
            this.blinkButton.Text = "Blink Monitor";
            this.blinkButton.UseVisualStyleBackColor = true;
            this.blinkButton.Click += new System.EventHandler(this.blinkButton_Click);
            // 
            // showGazeRegionsButton
            // 
            this.showGazeRegionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showGazeRegionsButton.Location = new System.Drawing.Point(117, 302);
            this.showGazeRegionsButton.Margin = new System.Windows.Forms.Padding(0);
            this.showGazeRegionsButton.Name = "showGazeRegionsButton";
            this.showGazeRegionsButton.Size = new System.Drawing.Size(117, 32);
            this.showGazeRegionsButton.TabIndex = 13;
            this.showGazeRegionsButton.Text = "Show Gaze Regions";
            this.showGazeRegionsButton.UseVisualStyleBackColor = true;
            this.showGazeRegionsButton.Click += new System.EventHandler(this.showGazeRegionsButton_Click);
            // 
            // mouseMoverButton
            // 
            this.mouseMoverButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mouseMoverButton.Location = new System.Drawing.Point(117, 376);
            this.mouseMoverButton.Margin = new System.Windows.Forms.Padding(0);
            this.mouseMoverButton.Name = "mouseMoverButton";
            this.mouseMoverButton.Size = new System.Drawing.Size(117, 32);
            this.mouseMoverButton.TabIndex = 14;
            this.mouseMoverButton.Text = "Mouse Mover";
            this.mouseMoverButton.UseVisualStyleBackColor = true;
            this.mouseMoverButton.Click += new System.EventHandler(this.mouseMoverButton_Click);
            // 
            // editProfileButton
            // 
            this.editProfileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editProfileButton.Location = new System.Drawing.Point(0, 32);
            this.editProfileButton.Margin = new System.Windows.Forms.Padding(0);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(117, 32);
            this.editProfileButton.TabIndex = 15;
            this.editProfileButton.Text = "Edit Profile";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // cloneProfileButton
            // 
            this.cloneProfileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloneProfileButton.Location = new System.Drawing.Point(117, 32);
            this.cloneProfileButton.Margin = new System.Windows.Forms.Padding(0);
            this.cloneProfileButton.Name = "cloneProfileButton";
            this.cloneProfileButton.Size = new System.Drawing.Size(117, 32);
            this.cloneProfileButton.TabIndex = 16;
            this.cloneProfileButton.Text = "Clone Profile";
            this.cloneProfileButton.UseVisualStyleBackColor = true;
            this.cloneProfileButton.Click += new System.EventHandler(this.cloneProfileButton_Click);
            // 
            // EyeBindMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 448);
            this.Controls.Add(this.tableLayoutPanel);
            this.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::EyeBind.Properties.Settings.Default, "mainWindowTopMost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MaximizeBox = false;
            this.Name = "EyeBindMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeBind";
            this.TopMost = global::EyeBind.Properties.Settings.Default.MainWindowTopMost;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ProfilesComboBox profilesComboBox;
        private GazeRegionsListBox gazeRegionsListBox;
        private System.Windows.Forms.Button deleteProfileButton;
        private System.Windows.Forms.Button newProfileButton;
        private System.Windows.Forms.Button newGazeRegionButton;
        private System.Windows.Forms.Button deleteGazeRegionButton;
        private System.Windows.Forms.Button editGazeRegionButton;
        private System.Windows.Forms.Button cloneGazeRegionButton;
        private System.Windows.Forms.CheckBox gazeMarkerCheckBox;
        private System.Windows.Forms.CheckBox pauseSimulationCheckBox;
        private System.Windows.Forms.Button hideGazeRegionsButton;
        private System.Windows.Forms.Button generalSettingsButton;
        private System.Windows.Forms.Button blinkButton;
        private System.Windows.Forms.Button showGazeRegionsButton;
        private System.Windows.Forms.Button mouseMoverButton;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.Button cloneProfileButton;

    }
}