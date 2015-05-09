using System.Media;

namespace EyeBind
{
    public static class GazeSoundPlayer
    {
        private const string blinkFileName = "blink.wav";

        private const string enterFileName = "enter.wav";
        private const string exitFileName = "exit.wav";

        private const string activationFileName = "activation.wav";
        private const string deactivationFileName = "deactivation.wav";

        private const string directoryName = "sounds";

        private static SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.button_click_0);

        private static SoundPlayer binkSoundPlayer;
        private static SoundPlayer enterSoundPlayer;
        private static SoundPlayer exitSoundPlayer;
        private static SoundPlayer activationSoundPlayer;
        private static SoundPlayer deactivationSoundPlayer;

        static GazeSoundPlayer()
        {
            soundPlayer.Load();
            InitializeSoundPlayers();
        }

        private static SoundPlayer LoadPlayer(System.IO.UnmanagedMemoryStream stream, string fileName)
        {
            try
            {
                string filePath = System.IO.Directory.GetCurrentDirectory();
                filePath += "\\" + directoryName + "\\" + fileName;

                if (System.IO.File.Exists(filePath))
                {
                    return new SoundPlayer(filePath);
                }
                else
                {
                    return new SoundPlayer(stream);
                }
            }
            catch
            {
                return new SoundPlayer(stream);
            }
        }

        private static void InitializeSoundPlayers()
        {
            binkSoundPlayer = LoadPlayer(Properties.Resources.blink, blinkFileName);
            binkSoundPlayer.Load();
            enterSoundPlayer = LoadPlayer(Properties.Resources.enter, enterFileName);
            enterSoundPlayer.Load();
            exitSoundPlayer = LoadPlayer(Properties.Resources.exit, exitFileName);
            exitSoundPlayer.Load();
            activationSoundPlayer = LoadPlayer(Properties.Resources.activation, activationFileName);
            activationSoundPlayer.Load();
            deactivationSoundPlayer = LoadPlayer(Properties.Resources.deactivation, deactivationFileName);
            deactivationSoundPlayer.Load();
        }

        public static void Play()
        {
            soundPlayer.Play();
        }

        public static void PlayBinkSound()
        {
            binkSoundPlayer.Play();
        }

        public static void PlayGazeEnterSound()
        {
            enterSoundPlayer.Play();
        }

        public static void PlayGazeExitSound()
        {
            exitSoundPlayer.Play();
        }

        public static void PlayGazeActivationSound()
        {
            activationSoundPlayer.Play();
        }

        public static void PlayGazeDeactivationSound()
        {
            deactivationSoundPlayer.Play();
        }
    }
}
