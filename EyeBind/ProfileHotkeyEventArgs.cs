using System;
using System.Windows.Forms;

namespace EyeBind
{
    class ProfileHotkeyEventArgs : EventArgs
    {
        private Keys key;
        private int profileIndex;

        public ProfileHotkeyEventArgs(Keys k, int index)
        {
            key = k;
            profileIndex = index;
        }

        public Keys Key
        {
            get { return key; }
        }

        public int ProfileIndex
        {
            get { return profileIndex; }
        }
    }
}
