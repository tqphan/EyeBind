using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsInput;
using WindowsInput.Native;
using EyeBind.Properties;

namespace EyeBind
{
    public class Eye : INotifyPropertyChanged
    {
        private bool eyeOpen;
        private double eyeCloseTimestamp;
        private int eyeCloseActivationDelay = 500;
        private int eyeCloseDuration;
        private bool eyeActivated;
        private BindingList<KeyboardInput> eyeInputs = new BindingList<KeyboardInput>();
        private InputSimulator inputSimulator = new InputSimulator();

        public Eye()
        {
        }

        public Eye(System.Xml.XmlNode xn)
        {
            this.FromXml(xn);
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public string Name
        {
            get;
            set;
        }

        public BindingList<KeyboardInput> EyeInputs
        {
            get
            {
                return this.eyeInputs;
            }
        }

        public int EyeCloseActivationDelay
        {
            get
            {
                return this.eyeCloseActivationDelay;
            }
            set
            {
                if (value != this.eyeCloseActivationDelay)
                {
                    this.eyeCloseActivationDelay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void ProcessEye(bool isValid, double timeStamp)
        {
            if (isValid)
            {
                if (!this.eyeOpen)
                {
                    this.eyeOpen = true;
                    this.OnEyeOpen(timeStamp);
                }
            }
            else
            {
                if (this.eyeOpen)
                {
                    this.eyeOpen = false;
                    this.OnEyeClose(timeStamp);
                }
                else
                {
                    this.OnEyeRemainsClose(timeStamp);
                }
            }
        }

        private void OnEyeOpen(double timeStamp)
        {
            this.eyeActivated = false;
        }

        private void OnEyeClose(double timeStamp)
        {
            this.eyeCloseTimestamp = timeStamp;
        }

        private void OnEyeRemainsClose(double timeStamp)
        {
            this.eyeCloseDuration = (int)(timeStamp - this.eyeCloseTimestamp);
            if (this.eyeCloseDuration > this.eyeCloseActivationDelay)
            {
                this.OnEyeActivation();
            }
        }

        private void OnEyeActivation()
        {
            if (!this.eyeActivated)
            {
                this.eyeActivated = true;
                
                if(!Settings.Default.InputSimulationPaused)
                    this.SimulateKeys(this.eyeInputs);

                if (Settings.Default.BlinkActivationSoundEnabled)
                    GazeSoundPlayer.Play();
            }
        }

        private void SimulateKeys(BindingList<KeyboardInput> kil)
        {
            foreach (KeyboardInput ki in kil)
            {
                switch (ki.KeyOperation)
                {
                    case KeyOperation.KeyDown:
                        this.inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyUp:
                        this.inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyPress:
                        inputSimulator.Keyboard.KeyPress(ki.VirtualKey);
                        break;
                    case KeyOperation.KeyToggle:
                        bool down = this.inputSimulator.InputDeviceState.IsKeyDown(ki.VirtualKey);
                        if (down)
                            this.inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                        else
                            this.inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                        break;
                }
            }
        }

        private void FromXml(System.Xml.XmlNode xn)
        {
            int i;
            System.Xml.XmlNode n = xn.SelectSingleNode(".//Delay");
            if (int.TryParse(n.InnerText, out i))
            {
                if (i >= 0)
                    this.eyeCloseActivationDelay = i;
            }

                
            n= xn.SelectSingleNode(".//Inputs");
            foreach (System.Xml.XmlNode lein in n.ChildNodes)
            {
                KeyOperation ko;
                if (Enum.TryParse(lein.Name, out ko))
                {
                    VirtualKeyCode vkc;
                    if (Enum.TryParse(lein.InnerText, out vkc))
                    {
                        this.eyeInputs.Add(new KeyboardInput(vkc, ko));
                    }
                }
            }
        }

        public System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            System.Xml.XmlElement root = xmlDoc.CreateElement(this.Name);

            System.Xml.XmlElement delay = xmlDoc.CreateElement("Delay");
            delay.InnerText = this.eyeCloseActivationDelay.ToString();
            root.AppendChild(delay);

            System.Xml.XmlElement inputs = xmlDoc.CreateElement("Inputs");

            foreach (KeyboardInput ki in this.eyeInputs)
            {
                System.Xml.XmlElement kie = xmlDoc.CreateElement(Enum.GetName(typeof(KeyOperation), ki.KeyOperation));
                kie.InnerText = ((int)ki.VirtualKey).ToString();
                inputs.AppendChild(kie);
            }

            root.AppendChild(inputs);

            xmlDoc.AppendChild(root);

            return xmlDoc;
        }
    }
}
