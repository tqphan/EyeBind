using System;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class GeneralSettingsDialog : Form
    {
        public GeneralSettingsDialog()
        {
            InitializeComponent();
        }

        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.moveMouseHotKeyTextBox.Text = Properties.Settings.Default.MouseMoveHotKey.ToString();
            this.toggleKeyboardSimulationHotKeyTextBox.Text = Properties.Settings.Default.ToggleKeyboardSimulationHotKey.ToString();
            this.toggleSoundsHotKeyTextBox.Text = Properties.Settings.Default.ToggleSoundsHotKey.ToString();
            this.toggleContinuousMouseMoveHotKeyTextBox.Text = Properties.Settings.Default.ToggleContinuousMouseMoveHotKey.ToString();
            this.toggleGazeMarkerHotKeyTextBox.Text = Properties.Settings.Default.ToggleGazeMarkerHotKey.ToString();

            this.moveMouseHotKeyTextBox.SettingKey = Properties.Settings.Default.MouseMoveHotKey;
            this.toggleKeyboardSimulationHotKeyTextBox.SettingKey = Properties.Settings.Default.ToggleKeyboardSimulationHotKey;
            this.toggleSoundsHotKeyTextBox.SettingKey = Properties.Settings.Default.ToggleSoundsHotKey;
            this.toggleContinuousMouseMoveHotKeyTextBox.SettingKey = Properties.Settings.Default.ToggleContinuousMouseMoveHotKey;
            this.toggleGazeMarkerHotKeyTextBox.SettingKey = Properties.Settings.Default.ToggleGazeMarkerHotKey;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnClosing(e);
            Properties.Settings.Default.MouseMoveHotKey = this.moveMouseHotKeyTextBox.SettingKey;
            Properties.Settings.Default.ToggleKeyboardSimulationHotKey = this.toggleKeyboardSimulationHotKeyTextBox.SettingKey;
            Properties.Settings.Default.ToggleSoundsHotKey = this.toggleSoundsHotKeyTextBox.SettingKey;
            Properties.Settings.Default.ToggleContinuousMouseMoveHotKey = this.toggleContinuousMouseMoveHotKeyTextBox.SettingKey;
            Properties.Settings.Default.ToggleGazeMarkerHotKey = this.toggleGazeMarkerHotKeyTextBox.SettingKey;
        }

        private void moveMouseHotKeyResetButton_Click(object sender, EventArgs e)
        {
            this.moveMouseHotKeyTextBox.SettingKey = Keys.None;
            this.moveMouseHotKeyTextBox.Text = Keys.None.ToString();
        }

        private void toggleKeyboardSimulationResetButton_Click(object sender, EventArgs e)
        {
            this.toggleKeyboardSimulationHotKeyTextBox.SettingKey = Keys.None;
            this.toggleKeyboardSimulationHotKeyTextBox.Text = Keys.None.ToString();
        }

        private void toggleSoundsHotKeyResetButton_Click(object sender, EventArgs e)
        {
            this.toggleSoundsHotKeyTextBox.SettingKey = Keys.None;
            this.toggleSoundsHotKeyTextBox.Text = Keys.None.ToString();
        }

        private void continuousMouseMoveHotKeyResetButton_Click(object sender, EventArgs e)
        {
            this.toggleContinuousMouseMoveHotKeyTextBox.SettingKey = Keys.None;
            this.toggleContinuousMouseMoveHotKeyTextBox.Text = Keys.None.ToString();
        }

        private void toggleGazeMarkerHotKeyResetButton_Click(object sender, EventArgs e)
        {
            this.toggleGazeMarkerHotKeyTextBox.SettingKey = Keys.None;
            this.toggleGazeMarkerHotKeyTextBox.Text = Keys.None.ToString();
        }
    }
}
