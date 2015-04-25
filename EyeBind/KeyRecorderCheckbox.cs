using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;

namespace EyeBind
{
    public class KeyRecorderCheckBox : CheckBox
    {
        BindingList<KeyboardInput> keyboardInputBindingList = new BindingList<KeyboardInput>();

        private const string startRecord = "⚫ Start Recording Key";
        private const string stopRecord = "◼ Stop Recording Key";

        public KeyRecorderCheckBox()
        {
            this.Appearance = System.Windows.Forms.Appearance.Button;
            this.Text = startRecord;
        }

        public BindingList<KeyboardInput> KeyboardInputBindingList
        {
            set
            {
                this.keyboardInputBindingList = value;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if(this.Checked)
                this.AddKey(e, KeyOperation.KeyDown);

            e.Handled = true;

            if (e.KeyCode == Keys.Space)
                return;
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (this.Checked)
                this.AddKey(e, KeyOperation.KeyUp);

            e.Handled = true;
            if (e.KeyCode == Keys.Space)
                return;
            base.OnKeyUp(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            e.IsInputKey = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Checked = false;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if(this.Checked)
            {
                this.Text = stopRecord;
            }
            else
            {
                this.Text = startRecord;
            }
        }

        private void AddKey(KeyEventArgs kea, KeyOperation ko)
        {
            int kc = (int)kea.KeyCode;
            VirtualKeyCode vkc = (VirtualKeyCode)kc;
            KeyboardInput ki = new KeyboardInput(vkc, ko);
            this.keyboardInputBindingList.Add(ki);
        }
    }
}
