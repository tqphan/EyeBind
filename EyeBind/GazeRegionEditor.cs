using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class GazeRegionEditor : Form
    {
        GazeRegion gazeRegion;
        private GazeRegionEditor()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public GazeRegionEditor(GazeRegion gr) : this()
        {
            this.gazeRegion = gr;
            InitializeMoreComponent();
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
            this.gazeRegionNameTextBox.DataBindings.Add("Text", this.gazeRegion, "RegionName", false, DataSourceUpdateMode.OnPropertyChanged);

            this.leftNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "Left", new IntDecimalConverter()));
            this.topNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "Top", new IntDecimalConverter()));
            this.widthNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "Width", new IntDecimalConverter()));
            this.heightNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "Height", new IntDecimalConverter()));

            this.topMostCheckBox.DataBindings.Add("Checked", this.gazeRegion, "TopMost", false, DataSourceUpdateMode.OnPropertyChanged);

            this.gazeRegionOpacityTrackBar.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "Opacity", new DoubleIntConverter()));

            this.gazeEnterColorButton.DataBindings.Add("BackColor", this.gazeRegion, "GazeEnterColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.gazeExitColorButton.DataBindings.Add("BackColor", this.gazeRegion, "GazeExitColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.activationColorButton.DataBindings.Add("BackColor", this.gazeRegion, "GazeActivationColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.deactivationColorButton.DataBindings.Add("BackColor", this.gazeRegion, "GazeDeactivationColor", false, DataSourceUpdateMode.OnPropertyChanged);

            this.activationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "ActivationDelay", new IntDecimalConverter()));
            this.deactivationDelayNumericUpDown.DataBindings.Add(new CustomBinding("Value", this.gazeRegion, "DeactivationDelay", new IntDecimalConverter()));

            this.InitializeDataGridView(this.gazeEnterInputsDataGridView, this.gazeRegion.GazeEnterInputs);
            this.gazeEnterKeyRecorderCheckBox.KeyboardInputBindingList = this.gazeRegion.GazeEnterInputs;
            this.InitializeDataGridView(this.gazeExitInputsDataGridView, this.gazeRegion.GazeExitInputs);
            this.gazeExitKeyRecorderCheckBox.KeyboardInputBindingList = this.gazeRegion.GazeExitInputs;
        }

        private void UnsetBindings()
        {
            this.gazeRegionNameTextBox.DataBindings.Clear();

            this.leftNumericUpDown.DataBindings.Clear();
            this.topNumericUpDown.DataBindings.Clear();
            this.widthNumericUpDown.DataBindings.Clear();
            this.heightNumericUpDown.DataBindings.Clear();

            this.topMostCheckBox.DataBindings.Clear();

            this.gazeRegionOpacityTrackBar.DataBindings.Clear();

            this.gazeEnterColorButton.DataBindings.Clear();
            this.gazeExitColorButton.DataBindings.Clear();
            this.activationColorButton.DataBindings.Clear();
            this.deactivationColorButton.DataBindings.Clear();

            this.activationDelayNumericUpDown.DataBindings.Clear();
            this.deactivationDelayNumericUpDown.DataBindings.Clear();

            this.gazeEnterInputsDataGridView.DataSource = null;
            this.gazeExitInputsDataGridView.DataSource = null;

            this.gazeRegion = null;
        }

        private void InitializeMoreComponent()
        {
            this.leftNumericUpDown.Minimum = int.MinValue;
            this.leftNumericUpDown.Maximum = int.MaxValue;

            this.topNumericUpDown.Minimum = int.MinValue;
            this.topNumericUpDown.Maximum = int.MaxValue;

            this.widthNumericUpDown.Minimum = int.MinValue;
            this.widthNumericUpDown.Maximum = int.MaxValue;

            this.heightNumericUpDown.Minimum = int.MinValue;
            this.heightNumericUpDown.Maximum = int.MaxValue;
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

        private void gazeEnterColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.gazeEnterColorButton.BackColor = colorDialog.Color;
            }
        }

        private void gazeExitColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.gazeExitColorButton.BackColor = colorDialog.Color;
            }
        }

        private void activationColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.activationColorButton.BackColor = colorDialog.Color;
            }
        }

        private void deactivationColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.deactivationColorButton.BackColor = colorDialog.Color;
            }
        }

        private void clearGazeEnterKeyboardInputsButton_Click(object sender, EventArgs e)
        {
            this.gazeRegion.GazeEnterInputs.Clear();
        }

        private void clearGazeExitKeyboardInputsButton_Click(object sender, EventArgs e)
        {
            this.gazeRegion.GazeExitInputs.Clear();
        }
    }
}
