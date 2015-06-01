using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public class GazeProfilesBindingList<T> : BindingList<GazeRegionProfile>
    {
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);

            switch(e.ListChangedType)
            {
                case ListChangedType.Reset:
                    HotkeyManager.ClearHotkeys();
                    break;

                case ListChangedType.ItemAdded:
                    if(e.NewIndex > -1)
                    {
                        Keys k = ((EyeBind.GazeRegionProfile)this[e.NewIndex]).Hotkey;
                        VerifyHotKeyUniqueness(k, e.NewIndex);
                        HotkeyManager.RegisterHotkey(k, e.NewIndex);
                    }
                    break;

                case ListChangedType.ItemDeleted:
                    if (e.NewIndex > -1)
                    {
                        HotkeyManager.ClearHotkeys();
                        RegisterHotKeys();
                    }
                    break;

                case ListChangedType.ItemChanged:
                    if (e.NewIndex > -1)
                    {
                        Keys k = ((EyeBind.GazeRegionProfile)this[e.NewIndex]).Hotkey;
                        VerifyHotKeyUniqueness(k, e.NewIndex);
                        HotkeyManager.ClearHotkeys();
                        RegisterHotKeys();
                    }
                    break;
            }
        }

        private void VerifyHotKeyUniqueness(Keys key, int index)
        {
            for(int i = 0; i < this.Count; i++)
            {
                if (i == index)
                    continue;

                Keys k = ((EyeBind.GazeRegionProfile)this[i]).Hotkey;
                if (k == key)
                    ((EyeBind.GazeRegionProfile)this[i]).Hotkey = Keys.None;
            }
        }

        private void RegisterHotKeys()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Keys k = ((EyeBind.GazeRegionProfile)this[i]).Hotkey;
                HotkeyManager.RegisterHotkey(k, i);
            }
        }
    }
}
