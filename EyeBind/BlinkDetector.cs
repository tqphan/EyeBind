using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeBind
{
    public static class BlinkDetector
    {
        private static EyeSetting leftEyeSetting = new EyeSetting();
        private static EyeSetting rightEyeSetting = new EyeSetting();

        private static Eye leftEye = new Eye();
        private static Eye rightEye = new Eye();

        private static bool enabled;

        public static bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (value != enabled)
                {
                    enabled = value;

                    if (value)
                    {
                        Program.EyePositionDataStream.Next += EyePositionDataStream_Next;
                    }
                    else
                    {
                        Program.EyePositionDataStream.Next -= EyePositionDataStream_Next;
                    }
                }
            }
        }

        public static void ChangeBlinkSetting(EyeSetting leftEye, EyeSetting rightEye)
        {
            leftEyeSetting = leftEye;
            rightEyeSetting = rightEye;
        }

        private static void EyePositionDataStream_Next(object sender, EyeXFramework.EyePositionEventArgs e)
        {
            if (leftEyeSetting.Enabled)
                leftEye.ProcessEye(e.LeftEye.IsValid, e.Timestamp, leftEyeSetting);

            if (rightEyeSetting.Enabled)
                rightEye.ProcessEye(e.RightEye.IsValid, e.Timestamp, rightEyeSetting);
        }
    }
}
