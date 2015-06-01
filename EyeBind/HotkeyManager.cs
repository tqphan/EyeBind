using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EyeBind
{
    static class HotkeyManager
    {
        private static Dictionary<Keys, int> profilesKeysHotkey = new Dictionary<Keys, int>();
        private static KeyboardHookListener keyboardHookManager = new KeyboardHookListener(new GlobalHooker());

        public static EventHandler<ProfileHotkeyEventArgs> OnProfileHotkeyTriggered;
        public static EventHandler<EventArgs> OnToggleSimulationHotkeyTriggered;
        public static EventHandler<EventArgs> OnToggleSoundHotkeyTriggered;
        public static EventHandler<EventArgs> OnToggleGazeMarkerHotkeyTriggered;
        public static EventHandler<EventArgs> OnToggleContinuousMouseMoveHotkeyTriggered;
        public static EventHandler<EventArgs> OnMouseMoveHotkeyTriggered;

        static HotkeyManager()
        {
            keyboardHookManager.KeyUp += keyboardHookManager_KeyUp;
        }

        private static void keyboardHookManager_KeyUp(object sender, KeyEventArgs e)
        {
            if (profilesKeysHotkey.ContainsKey(e.KeyData))
            {
                ProfileHotkeyEventArgs args = new ProfileHotkeyEventArgs(e.KeyData, profilesKeysHotkey[e.KeyData]);
                RaiseProfileHotkeyTriggered(args);
            }

            if (e.KeyData == Properties.Settings.Default.ToggleSoundsHotKey)
            {
                RaiseToggleSoundHotkeyTriggered(new EventArgs());
            }

            if (e.KeyData == Properties.Settings.Default.ToggleKeyboardSimulationHotKey)
            {
                RaiseToggleSimulationHotkeyTriggered(new EventArgs());
            }

            if (e.KeyData == Properties.Settings.Default.MouseMoveHotKey)
            {
                RaiseMouseMoveHotkeyTriggered(new EventArgs());
            }

            if (e.KeyData == Properties.Settings.Default.ToggleContinuousMouseMoveHotKey)
            {
                RaiseToggleContinuousMouseMoveHotkeyTriggered(new EventArgs());
            }

            if (e.KeyData == Properties.Settings.Default.ToggleGazeMarkerHotKey)
            {
                RaiseToggleGazeMarkerHotkeyTriggered(new EventArgs());
            }
        }

        private static void RaiseProfileHotkeyTriggered(ProfileHotkeyEventArgs e)
        {
            EventHandler<ProfileHotkeyEventArgs> handler = OnProfileHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void RaiseToggleSimulationHotkeyTriggered(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnToggleSimulationHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void RaiseToggleSoundHotkeyTriggered(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnToggleSoundHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void RaiseMouseMoveHotkeyTriggered(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnMouseMoveHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void RaiseToggleContinuousMouseMoveHotkeyTriggered(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnToggleContinuousMouseMoveHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void RaiseToggleGazeMarkerHotkeyTriggered(EventArgs e)
        {
            EventHandler<EventArgs> handler = OnToggleGazeMarkerHotkeyTriggered;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        public static bool Enabled
        {
            get
            {
                return keyboardHookManager.Enabled;
            }
            set
            {
                keyboardHookManager.Enabled = value;
            }
        }

        public static void ClearHotkeys()
        {
            profilesKeysHotkey.Clear();
        }

        public static bool RegisterHotkey(Keys key, int profileIndex)
        {
            if (key != Keys.None)
            {
                if (!profilesKeysHotkey.ContainsKey(key))
                {
                    profilesKeysHotkey.Add(key, profileIndex);
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool IsProfileHotkeyUsed(Keys key)
        {
            if (profilesKeysHotkey.ContainsKey(key))
                return true;
            else
                return false;
        }
    }
}
