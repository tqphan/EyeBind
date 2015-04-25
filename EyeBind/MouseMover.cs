using System;
using System.Runtime.InteropServices;

namespace EyeBind
{
    public class MouseMover
    {
        private bool enabled;

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

        private void FixationDataStream_Next(object sender, EyeXFramework.FixationEventArgs e)
        {
            SetCursorPos((int)e.X, (int)e.Y);
        }
    }
}
