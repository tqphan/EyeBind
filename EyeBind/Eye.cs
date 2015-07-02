using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsInput;
using WindowsInput.Native;
using EyeBind.Properties;

namespace EyeBind
{
    public class Eye
    {
        private bool eyeOpen;
        private double eyeCloseTimestamp;
        private int eyeCloseDuration;
        private bool eyeActivated;
        private InputSimulator inputSimulator = new InputSimulator();

        public Eye()
        {
        }

        public void Reset()
        {
            eyeOpen = false;
            eyeCloseTimestamp = 0;
            eyeActivated = false;
            eyeCloseDuration = 0;
        }

        public void ProcessEye(bool isValid, double timeStamp, EyeSetting eyeSetting)
        {
            if (isValid)
            {
                if (!eyeOpen)
                {
                    eyeOpen = true;
                    OnEyeOpen(timeStamp);
                }
            }
            else
            {
                if (eyeOpen)
                {
                    eyeOpen = false;
                    OnEyeClose(timeStamp);
                }
                else
                {
                    OnEyeRemainsClose(timeStamp, eyeSetting);
                }
            }
        }

        private void OnEyeOpen(double timeStamp)
        {
            eyeActivated = false;
        }

        private void OnEyeClose(double timeStamp)
        {
            eyeCloseTimestamp = timeStamp;
        }

        private void OnEyeRemainsClose(double timeStamp, EyeSetting eyeSetting)
        {
            eyeCloseDuration = (int)(timeStamp - eyeCloseTimestamp);
            if (eyeCloseDuration > eyeSetting.EyeCloseActivationDelay)
            {
                OnEyeActivation(eyeSetting.EyeCloseInputs);
            }
        }

        private void OnEyeActivation(BindingList<KeyboardInput> eyeInputs)
        {
            if (!eyeActivated)
            {
                eyeActivated = true;
                
                if(!Settings.Default.InputSimulationPaused)
                    SimulateKeys(eyeInputs);

                if (Settings.Default.BlinkActivationSoundEnabled && Settings.Default.GlobalSoundEnabled)
                    GazeSoundPlayer.PlayBinkSound();
            }
        }

        private void SimulateKeys(BindingList<KeyboardInput> kil)
        {
            foreach (KeyboardInput ki in kil)
            {
                switch (ki.KeyOperation)
                {
                    case KeyOperation.KeyDown:
                        inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyUp:
                        inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyPress:
                        inputSimulator.Keyboard.KeyPress(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyToggle:
                        bool down = inputSimulator.InputDeviceState.IsKeyDown(ki.VirtualKey);
                        if (down)
                            inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                        else
                            inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                        break;
                }
            }
        }
    }
}
