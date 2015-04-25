using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EyeBind
{
    public class KeyboardInput
    {
        private WindowsInput.Native.VirtualKeyCode vkc;
        private KeyOperation ko;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public KeyboardInput(WindowsInput.Native.VirtualKeyCode vkc, KeyOperation ko)
        {
            this.vkc = vkc;
            this.ko = ko;
        }
        public KeyOperation KeyOperation
        {
            get
            {
                return this.ko;
            }
            set
            {
                if (value != this.ko)
                {
                    this.ko = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public WindowsInput.Native.VirtualKeyCode VirtualKey
        {
            get
            {
                return this.vkc;
            }
            set
            {
                if (value != this.vkc)
                {
                    this.vkc = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
