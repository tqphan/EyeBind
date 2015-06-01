using System;
using System.Windows.Forms;
using EyeXFramework;

namespace EyeBind
{
    static class Program
    {
        private static string eyeBindVersion = "1.2";
        private static string eyeBindName = "EyeBind";
        private static EyeXHost _eyeXHost;
        private static EyeXFramework.GazePointDataStream gazePointDataStream = null;
        private static EyeXFramework.FixationDataStream fixationDataStream = null;
        private static EyeXFramework.EyePositionDataStream eyePositionDataStream = null;

        public static EyeXFramework.GazePointDataStream GazePointDataStream
        {
            get
            {
                return gazePointDataStream;
            }
        }

        public static EyeXFramework.FixationDataStream FixationDataStream
        {
            get
            {
                return fixationDataStream;
            }
        }

        public static EyeXFramework.EyePositionDataStream EyePositionDataStream
        {
            get
            {
                return eyePositionDataStream;
            }
        }

        /// <summary>
        /// Gets the singleton EyeX host instance.
        /// </summary>
        public static EyeXHost EyeXHost
        {
            get { return _eyeXHost; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ProcessChecker.IsOnlyProcess(eyeBindName))
            {
                try
                {
                    _eyeXHost = new EyeXHost();
                    _eyeXHost.Start();
                    gazePointDataStream = _eyeXHost.CreateGazePointDataStream(Tobii.EyeX.Framework.GazePointDataMode.LightlyFiltered);
                    fixationDataStream = _eyeXHost.CreateFixationDataStream(Tobii.EyeX.Framework.FixationDataMode.Slow);
                    eyePositionDataStream = _eyeXHost.CreateEyePositionDataStream();
                }
                catch
                {
                    MessageBox.Show("Fail to start EyeXHost.");
                    return;
                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new EyeBindMainForm());

                gazePointDataStream.Dispose();
                fixationDataStream.Dispose();
                eyePositionDataStream.Dispose();
                _eyeXHost.Dispose();
            }
        }
    }
}
