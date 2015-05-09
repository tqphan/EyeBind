using System;
using System.Runtime.InteropServices;

namespace EyeBind
{
    public class MouseMover
    {
        private bool enabled;
        private bool continuousMouseMoveEnabled;
        private int lastX;
        private int lastY;

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if(value != this.enabled)
                {
                    this.enabled = value;
                    if(value)
                    {
                        Program.FixationDataStream.Next -= FixationDataStream_Next;
                        Program.FixationDataStream.Next += FixationDataStream_Next;
                    }
                    else
                    {
                        Program.FixationDataStream.Next -= FixationDataStream_Next;
                    }
                }
            }
        }

        public bool ContinuousMouseMoveEnabled
        {
            get
            {
                return this.continuousMouseMoveEnabled;
            }
            set
            {
                this.continuousMouseMoveEnabled = value;
            }
        }

        private void FixationDataStream_Next(object sender, EyeXFramework.FixationEventArgs e)
        {
            int x = (int)e.X;
            int y = (int)e.Y;

            this.lastX = x;
            this.lastY = y;

            if(this.continuousMouseMoveEnabled)
                SetCursorPos(x, y);
        }

        public void MoveMouse()
        {
            SetCursorPos(this.lastX, this.lastY);
        }
    }
}
