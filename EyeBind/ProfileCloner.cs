using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class ProfileCloner : Form
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

        public List<bool> RegionsToClone
        {
            get;
            private set;
        }

        private ProfileCloner()
        {
            InitializeComponent();
        }

        public ProfileCloner(List<string> regionName, string profileName): this()
        {
            this.RegionsToClone = new List<bool>();

            this.listView1.Columns.Add("Gaze Region");
            this.listView1.View = View.Details;
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (string str in regionName)
            {
                var item = new ListViewItem(new[] { str });
                listView1.Items.Add(item);
            }

            this.profileNameTextBox.Text = profileName;
            this.profileHotKeyTextBox.SettingKey = Keys.None;
            this.profileHotKeyTextBox.Text = Keys.None.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void profileHotkeyResetButton_Click(object sender, EventArgs e)
        {
            this.profileHotKeyTextBox.SettingKey = Keys.None;
            this.profileHotKeyTextBox.Text = Keys.None.ToString();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lvi in this.listView1.Items)
            {
                lvi.Checked = true;
            }
        }

        private void selectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                lvi.Checked = false;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                this.RegionsToClone.Add(this.listView1.Items[i].Checked);
            }

            this.ProfileName = this.profileNameTextBox.Text;
            this.Hotkey = this.profileHotKeyTextBox.SettingKey;
        }
    }
}
