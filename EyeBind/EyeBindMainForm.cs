using System;
using System.ComponentModel;
using System.Windows.Forms;
using EyeBind.Properties;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace EyeBind
{
    public partial class EyeBindMainForm : Form
    {
        private GazeProfilesBindingList<GazeRegionProfile> profilesList = new GazeProfilesBindingList<GazeRegionProfile>();
        private ScreenOverlay gazeMarkerTool;

        #region Properties
        public GazeRegionsListBox GazeRegionsListBox
        {
            get
            {
                return this.gazeRegionsListBox;
            }
        }

        public BindingList<GazeRegionProfile> ProfilesList
        {
            get
            {
                return this.profilesList;
            }
        }
        #endregion

        public EyeBindMainForm()
        {
            InitializeComponent();

            this.SetPauseSimulationCheckBoxText();
        }

        #region Global Keyboard Hook
        private void SetHotKeysHandlers()
        {
            HotkeyManager.OnToggleSimulationHotkeyTriggered += OnToggleSimulationHotkeyTriggered;
            HotkeyManager.OnToggleSoundHotkeyTriggered += OnToggleSoundHotkeyTriggered;
            HotkeyManager.OnMouseMoveHotkeyTriggered += OnMouseMoveHotkeyTriggered;
            HotkeyManager.OnToggleContinuousMouseMoveHotkeyTriggered += OnToggleContinuousMouseMoveHotkeyTriggered;
            HotkeyManager.OnToggleGazeMarkerHotkeyTriggered += OnToggleGazeMarkerHotkeyTriggered;
            HotkeyManager.OnProfileHotkeyTriggered += OnProfileHotkeyTriggered;
        }

        private void OnProfileHotkeyTriggered(object sender, ProfileHotkeyEventArgs e)
        {
            try
            {
                if (this.profilesComboBox.SelectedIndex != e.ProfileIndex)
                    this.profilesComboBox.SelectedIndex = e.ProfileIndex;
            }
            catch { }
        }

        public void OnToggleSoundHotkeyTriggered(object sender, EventArgs args)
        {
            Properties.Settings.Default.GlobalSoundEnabled = !Properties.Settings.Default.GlobalSoundEnabled;
        }

        public void OnToggleSimulationHotkeyTriggered(object sender, EventArgs args)
        {
            this.SetSimulationState(!GetSimulationState());
        }

        public void OnMouseMoveHotkeyTriggered(object sender, EventArgs args)
        {
            MouseMover.MoveMouse();
        }

        public void OnToggleContinuousMouseMoveHotkeyTriggered(object sender, EventArgs args)
        {
            MouseMover.ContinuousMouseMoveEnabled = !MouseMover.ContinuousMouseMoveEnabled;
        }

        public void OnToggleGazeMarkerHotkeyTriggered(object sender, EventArgs args)
        {
            this.gazeMarkerCheckBox.Checked = !this.gazeMarkerCheckBox.Checked;
        }
        #endregion

        #region overrides

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ActiveControl = null;
            this.LoadProfiles();
            this.LoadLastUsedProfile();
            BlinkDetector.Enabled = true;
            MouseMover.Enabled = true;
            this.SetHotKeysHandlers();
            HotkeyManager.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnClosing(e);
            HotkeyManager.Enabled = false;
            BlinkDetector.Enabled = false;
            MouseMover.Enabled = false;
            this.SaveProfiles("profile.xml");
            this.SaveLastUsedProfile();
            Properties.Settings.Default.Save();
            this.CloseAllGazeRegions();
        }
        #endregion

        private void CloseAllGazeRegions()
        {
            foreach (GazeRegionProfile grf in this.profilesList)
            {
                foreach (GazeRegion gr in grf.Profile)
                {
                    gr.Close();
                }
            }
        }

        #region Profiles Processing

        private void LoadProfiles()
        {
            try
            {
                string filePath = System.IO.Directory.GetCurrentDirectory();
                filePath += "\\profile\\profile.xml";

                if (!System.IO.File.Exists(filePath))
                {
                    this.LoadXmlFromResource(Properties.Resources.default_profile);
                    return;
                }

                this.LoadXmlFromFilePath(filePath);
            }
            catch
            {
                //TO-DO: notify user
                this.LoadXmlFromResource(Properties.Resources.default_profile);
            }
        }

        private void LoadXmlFromFilePath(string filePath)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(filePath);
            this.ProcessProfilesXml(xmlDoc);
        }

        private void LoadXmlFromResource(string xml)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xml);
            this.ProcessProfilesXml(xmlDoc);
        }

        private void ProcessProfilesXml(System.Xml.XmlDocument xmlDoc)
        {
            System.Xml.XmlNodeList grNodes = xmlDoc.SelectNodes("/EyeBind/GazeRegionProfile");
            this.profilesList.Clear();

            foreach (System.Xml.XmlNode xn in grNodes)
            {
                this.profilesList.Add(new GazeRegionProfile(xn));
            }

            this.profilesComboBox.DataSource = this.profilesList;
            this.profilesComboBox.DisplayMember = "DisplayName";
        }

        private bool SaveProfiles(string fileName)
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.AppendChild(xmlDoc.CreateElement("EyeBind"));

                System.Xml.XmlDocument xd;
                System.Xml.XmlDocumentFragment xfrag;

                foreach (GazeRegionProfile grp in this.profilesList)
                {
                    xd = grp.ToXml();
                    xfrag = xmlDoc.CreateDocumentFragment();
                    xfrag.InnerXml = xd.OuterXml;
                    xmlDoc.DocumentElement.AppendChild(xfrag);
                }

                string currentDir = System.IO.Directory.GetCurrentDirectory();
                currentDir += @"\profile\";


                bool exists = System.IO.Directory.Exists(currentDir);

                if (!exists)
                    System.IO.Directory.CreateDirectory(currentDir);

                currentDir += fileName;

                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(currentDir, System.Text.Encoding.UTF8))
                {
                    writer.Formatting = System.Xml.Formatting.Indented;
                    xmlDoc.Save(writer);
                }
            }
            catch
            {
                //TO-DO 
                return false;
            }
            return true;
        }

        #endregion

        #region Buttons/Checkboxes Handlers
        private void newProfileButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            this.profilesComboBox.AddProfile();
            HotkeyManager.Enabled = true;
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.RemoveSelectedProfile();
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            this.profilesComboBox.EditSelectedProfile();
            HotkeyManager.Enabled = true;
        }

        private void cloneProfileButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            this.profilesComboBox.CloneSelectedProfille();
            HotkeyManager.Enabled = true;
        }

        private void newGazeRegionButton_Click(object sender, EventArgs e)
        {
            this.gazeRegionsListBox.AddGazeRegion();
        }

        private void deleteGazeRegionButton_Click(object sender, EventArgs e)
        {
            this.gazeRegionsListBox.RemoveSelectedGazeRegion();
        }

        private void editGazeRegionButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            this.gazeRegionsListBox.EditSelectedGazeRegion();
            HotkeyManager.Enabled = true;
        }

        private void cloneGazeRegionButton_Click(object sender, EventArgs e)
        {
            this.gazeRegionsListBox.CloneSelectedGazeRegion();
        }

        private void hideGazeRegionsButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.HideSelectedProfile();
        }

        private void showGazeRegionsButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.ShowSelectedProfile();
        }

        private void pauseSimulationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SetPauseSimulationCheckBoxText();
        }

        private void gazeMarkerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.gazeMarkerCheckBox.Checked)
            {
                this.gazeMarkerTool = new ScreenOverlay();
                this.gazeMarkerTool.Show(this);
            }
            else
            {
                try
                {
                    this.gazeMarkerTool.Close();
                }
                catch
                {
                    //to-do
                }
            }
        }

        private void blinkButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            this.profilesComboBox.EditSelectedProfileBlinkSetting();
            HotkeyManager.Enabled = true;
        }

        private void mouseMoverButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            using (MouseMoverSettingsDialog mmsd = new MouseMoverSettingsDialog())
            {
                mmsd.ShowDialog();
                mmsd.Dispose();
            }
            HotkeyManager.Enabled = true;
        }

        private void generalSettingsButton_Click(object sender, EventArgs e)
        {
            HotkeyManager.Enabled = false;
            using (GeneralSettingsDialog gsd = new GeneralSettingsDialog())
            {
                gsd.ShowDialog();
                gsd.Dispose();
            }
            HotkeyManager.Enabled = true;
        }

        public void SetSimulationState(bool paused)
        {
            this.pauseSimulationCheckBox.Checked = paused;
        }

        public bool GetSimulationState()
        {
            return this.pauseSimulationCheckBox.Checked;
        }

        private void SetPauseSimulationCheckBoxText()
        {
            if (this.pauseSimulationCheckBox.Checked)
            {
                this.pauseSimulationCheckBox.Text = "Resume Simulation";
            }
            else
            {
                this.pauseSimulationCheckBox.Text = "Pause Simulation";
            }
        }
        #endregion

        #region last used profile
        private void LoadLastUsedProfile()
        {
            if (Settings.Default.LastUsedProfileIndex > -1)
            {
                try
                {
                    this.profilesComboBox.SelectedIndex = Settings.Default.LastUsedProfileIndex;
                }
                catch
                {
                    //to-do
                }
            }
        }

        private void SaveLastUsedProfile()
        {
            Settings.Default.LastUsedProfileIndex = this.profilesComboBox.SelectedIndex;
        }
        #endregion


    }
}
