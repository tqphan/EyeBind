using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeBind
{
    public class KeyboardKey
    {
        public int Scancode
        {
            get;
            set;
        }

        public int VirtualKey
        {
            get;
            set;
        }

        public bool ExtendedKey
        {
            get;
            set;
        }
    }
}
