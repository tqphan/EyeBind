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
        private BlinkMonitor blinkMonitor;

        public BlinkConfig()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public BlinkConfig(BlinkMonitor bm): this()
        {
            this.blinkMonitor = bm;
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
            this.leftEyeActivationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.blinkMonitor.LeftEye, "EyeCloseActivationDelay", new IntDecimalConverter()));
            this.rightEyeActivationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.blinkMonitor.RightEye, "EyeCloseActivationDelay", new IntDecimalConverter()));

            this.InitializeDataGridView(this.leftEyeKeyRecorderDataGridView, this.blinkMonitor.LeftEye.EyeInputs);
            this.leftEyeKeyRecorderCheckBox.KeyboardInputBindingList = this.blinkMonitor.LeftEye.EyeInputs;
            this.InitializeDataGridView(this.rightEyeKeyRecorderDataGridView, this.blinkMonitor.RightEye.EyeInputs);
            this.rightEyeKeyRecorderCheckBox.KeyboardInputBindingList = this.blinkMonitor.RightEye.EyeInputs;
        }

        private void UnsetBindings()
        {
            this.leftEyeActivationDelayNumericUpDown.DataBindings.Clear();
            this.rightEyeActivationDelayNumericUpDown.DataBindings.Clear();

            this.leftEyeKeyRecorderDataGridView.DataSource = null;
            this.rightEyeKeyRecorderDataGridView.DataSource = null;

            this.blinkMonitor = null;
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
            this.blinkMonitor.LeftEye.EyeInputs.Clear();
        }

        private void rightEyeClearInputsButton_Click(object sender, EventArgs e)
        {
            this.blinkMonitor.RightEye.EyeInputs.Clear();
        }
    }
}
