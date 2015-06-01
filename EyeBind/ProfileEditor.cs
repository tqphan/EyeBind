using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class ProfileEditor : Form
    {
        public string ProfileName
        {
            get;
            private set;
        }

        public Keys Hotkey
        {
            get;
            private set;
        }

        public ProfileEditor(string name, Keys hotkey): this()
        {
            this.profileNameTextBox.Text = name;
            this.profileHotKeyTextBox.Text = hotkey.ToString();

        }
        public ProfileEditor()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ProfileName = this.profileNameTextBox.Text;
            this.Hotkey = this.profileHotKeyTextBox.SettingKey;
        }

        private void profileHotkeyResetButton_Click(object sender, EventArgs e)
        {
            this.profileHotKeyTextBox.SettingKey = Keys.None;
            this.profileHotKeyTextBox.Text = Keys.None.ToString();
        }
    }
}
