using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EyeBind
{
    public static class GazeSoundPlayer
    {
        private static SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.button_click_0);
        static GazeSoundPlayer()
        {
            soundPlayer.Load();
        }

        public static void Play()
        {
            soundPlayer.Play();
        }
    }
}
