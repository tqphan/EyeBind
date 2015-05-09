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
        private KeyboardHookListener keyboardHookManager;
        private BindingList<GazeRegionProfile> profilesList = new BindingList<GazeRegionProfile>();
        private BlinkMonitor blinkMonitor;
        private MouseMover mouseMover = new MouseMover();
        private ScreenOverlay gazeMarkerTool;

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

        public EyeBindMainForm()
        {
            InitializeComponent();
            
            this.SetPauseSimulationCheckBoxText();

            this.SetGlobalKeyboardHook();

            this.mouseMover.Enabled = true;
        }

        #region Global Keyboard Hook
        private void SetGlobalKeyboardHook()
        {
            this.keyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            this.keyboardHookManager.Enabled = true;
            this.keyboardHookManager.KeyUp += keyboardHookManager_KeyUp;
        }

        private void keyboardHookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Properties.Settings.Default.ToggleKeyboardSimulationHotKey)
            {
                this.SetSimulationState(!GetSimulationState());
            }

            if(e.KeyData == Properties.Settings.Default.MouseMoveHotKey)
            {
                this.mouseMover.MoveMouse();
            }

            if(e.KeyData == Properties.Settings.Default.ToggleSoundsHotKey)
            {
                Properties.Settings.Default.GlobalSoundEnabled = !Properties.Settings.Default.GlobalSoundEnabled;
            }

            if (e.KeyData == Properties.Settings.Default.ToggleGazeMarkerHotKey)
            {
                this.gazeMarkerCheckBox.Checked = !this.gazeMarkerCheckBox.Checked;
            }

            if (e.KeyData == Properties.Settings.Default.ToggleContinuousMouseMoveHotKey)
            {
                this.mouseMover.ContinuousMouseMoveEnabled = !this.mouseMover.ContinuousMouseMoveEnabled;
            }
        }
        #endregion

        #region overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ActiveControl = null;
            this.LoadProfiles();
            this.LoadLastUsedProfile();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnClosing(e);
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

                if(!System.IO.File.Exists(filePath))
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
            this.profilesComboBox.DisplayMember = "Name";

            this.blinkMonitor = new BlinkMonitor(xmlDoc.SelectSingleNode("/EyeBind/BlinkMonitor"));
            this.blinkMonitor.Enabled = true;
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

                xd = this.blinkMonitor.ToXml();
                xfrag = xmlDoc.CreateDocumentFragment();
                xfrag.InnerXml = xd.OuterXml;
                xmlDoc.DocumentElement.AppendChild(xfrag);

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

        #region Buttons Clicks
        private void newProfileButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.AddProfile();
        }

        private void deleteProfileButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.RemoveSelectedProfile();
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
            this.gazeRegionsListBox.EditSelectedGazeRegion();
        }

        private void cloneGazeRegionButton_Click(object sender, EventArgs e)
        {
            this.gazeRegionsListBox.CloneSelectedGazeRegion();
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

        private void hideGazeRegionsButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.HideSelectedProfile();
        }

        private void showGazeRegionsButton_Click(object sender, EventArgs e)
        {
            this.profilesComboBox.ShowSelectedProfile();
        }

        private void blinkButton_Click(object sender, EventArgs e)
        {
            using(BlinkConfig bc = new BlinkConfig(this.blinkMonitor))
            {
                bc.ShowDialog();
                bc.Dispose();
            }
        }

        private void mouseMoverButton_Click(object sender, EventArgs e)
        {
            this.mouseMover.ContinuousMouseMoveEnabled = !this.mouseMover.ContinuousMouseMoveEnabled;
        }

        private void generalSettingsButton_Click(object sender, EventArgs e)
        {
            using (GeneralSettingsDialog gsd = new GeneralSettingsDialog())
            {
                this.keyboardHookManager.Enabled = false;
                gsd.ShowDialog();
                gsd.Dispose();
                this.keyboardHookManager.Enabled = true;
            }
        }
        #endregion

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
            if(this.pauseSimulationCheckBox.Checked)
            {
                this.pauseSimulationCheckBox.Text = "Resume Simulation";
            }
            else
            {
                this.pauseSimulationCheckBox.Text = "Pause Simulation";
            }
        }

        #region last used profile
        private void LoadLastUsedProfile()
        {
            if(Settings.Default.LastUsedProfileIndex > -1)
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
