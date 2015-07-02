using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using EyeBind.Properties;

namespace EyeBind
{
    public partial class MouseMoverSettingsDialog : Form
    {
        private MouseMoveMode MouseMoveMode
        {
            get
            {
                RadioButton checkedButton = groupBox2.Controls.OfType<RadioButton>().Where(button => button.Checked).First();
                return (MouseMoveMode)(checkedButton.Tag);
            }
            set
            {
                switch(value)
                {
                    case EyeBind.MouseMoveMode.WarpToGazePoint:
                        warpRadioButton.Checked = true;
                        break;
                    case EyeBind.MouseMoveMode.FollowGazePoint:
                        followRadioButton.Checked = true;
                        break;
                    case EyeBind.MouseMoveMode.FirstPersonShooter:
                        fpsRadioButton.Checked = true;
                        break;
                }
            }
        }   

        public MouseMoverSettingsDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            warpRadioButton.Tag = MouseMoveMode.WarpToGazePoint;
            followRadioButton.Tag = MouseMoveMode.FollowGazePoint;
            fpsRadioButton.Tag = MouseMoveMode.FirstPersonShooter;

            MouseMoveMode = Settings.Default.MouseMoveMode;

            warpStopDistanceTrackBar.Value = Settings.Default.MouseMoveStopDistance;

            followSpeedTrackBar.Value = Settings.Default.MouseMoveFollowSpeed;

            speedTrackBar.Value = Settings.Default.MouseMoveFirstPersonSpeed;
            accelerationTrackBar.Value = Settings.Default.MouseMoveFirstPersonSpeedMultiplier;

            hotKeyTextBox.SettingKey = Settings.Default.ToggleContinuousMouseMoveHotKey;
            hotKeyTextBox.Text = Settings.Default.ToggleContinuousMouseMoveHotKey.ToString();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            MouseMover.Mode = MouseMoveMode;
            MouseMover.StopDistance = warpStopDistanceTrackBar.Value;
            MouseMover.FollowSpeed = followSpeedTrackBar.Value;
            MouseMover.Speed = speedTrackBar.Value;
            MouseMover.Acceleration = accelerationTrackBar.Value;
            Settings.Default.ToggleContinuousMouseMoveHotKey = hotKeyTextBox.SettingKey;
        }

        private void hotkeyResetButton_Click(object sender, EventArgs e)
        {
            hotKeyTextBox.SettingKey = Keys.None;
            hotKeyTextBox.Text = Keys.None.ToString();
        }
    }
}
