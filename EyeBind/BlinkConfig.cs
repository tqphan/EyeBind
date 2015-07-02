using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class BlinkConfig : Form
    {
        private EyeSetting leftEyeSetting = new EyeSetting();
        private EyeSetting rightEyeSetting = new EyeSetting();

        public BlinkConfig()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public BlinkConfig(EyeSetting left, EyeSetting right)
            : this()
        {
            leftEyeSetting = left;
            rightEyeSetting = right;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SetBindings();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnClosing(e);
            this.UnsetBindings();
        }

        private void SetBindings()
        {
            leftEyeActivationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", leftEyeSetting, "EyeCloseActivationDelay", new IntDecimalConverter()));
            rightEyeActivationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", rightEyeSetting, "EyeCloseActivationDelay", new IntDecimalConverter()));

            leftEyeBinkEnabledCheckBox.DataBindings.Add("Checked", leftEyeSetting, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged);
            rightEyeBinkEnabledCheckBox.DataBindings.Add("Checked", rightEyeSetting, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged);

            InitializeDataGridView(leftEyeKeyRecorderDataGridView, leftEyeSetting.EyeCloseInputs);
            leftEyeKeyRecorderCheckBox.KeyboardInputBindingList = leftEyeSetting.EyeCloseInputs;

            InitializeDataGridView(rightEyeKeyRecorderDataGridView, rightEyeSetting.EyeCloseInputs);
            rightEyeKeyRecorderCheckBox.KeyboardInputBindingList = rightEyeSetting.EyeCloseInputs;
        }

        private void UnsetBindings()
        {
            leftEyeActivationDelayNumericUpDown.DataBindings.Clear();
            rightEyeActivationDelayNumericUpDown.DataBindings.Clear();

            leftEyeBinkEnabledCheckBox.DataBindings.Clear();
            rightEyeBinkEnabledCheckBox.DataBindings.Clear();

            leftEyeKeyRecorderDataGridView.DataSource = null;
            rightEyeKeyRecorderDataGridView.DataSource = null;

            leftEyeSetting = null;
            rightEyeSetting = null;
        }

        private void InitializeDataGridView(KeyRecorderDataGridView krdgv, BindingList<KeyboardInput> blki)
        {
            krdgv.AutoGenerateColumns = false;
            krdgv.AutoSize = true;
            krdgv.DataSource = blki;

            DataGridViewComboBoxColumn cbc = new DataGridViewComboBoxColumn();
            cbc.DataSource = Enum.GetValues(typeof(KeyOperation));
            cbc.DataPropertyName = "KeyOperation";
            krdgv.Columns.Add(cbc);

            DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
            tbc.DataPropertyName = "VirtualKey";
            krdgv.Columns.Add(tbc);

            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bc.Text = "X";
            bc.UseColumnTextForButtonValue = true;
            bc.Width = 30;
            krdgv.Columns.Add(bc);

            krdgv.AllowUserToResizeRows = false;
            krdgv.AllowUserToResizeColumns = false;
            krdgv.AutoResizeColumns();
            krdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            krdgv.Columns[1].ReadOnly = true;
        }

        private void leftEyeClearInputsButton_Click(object sender, EventArgs e)
        {
            leftEyeSetting.EyeCloseInputs.Clear();
        }

        private void rightEyeClearInputsButton_Click(object sender, EventArgs e)
        {
            rightEyeSetting.EyeCloseInputs.Clear();
        }
    }
}
