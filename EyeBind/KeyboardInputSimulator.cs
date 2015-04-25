using System;
using System.ComponentModel;
using WindowsInput;
using WindowsInput.Native;

namespace EyeBind
{
    public class KeyboardInputSimulator
    {
        private BindingList<KeyboardInput> gazeEnterInputs = new BindingList<KeyboardInput>();
        private BindingList<KeyboardInput> gazeExitInputs = new BindingList<KeyboardInput>();
        private InputSimulator inputSimulator = new InputSimulator();

        public KeyboardInputSimulator()
        {

        }

        public KeyboardInputSimulator(System.Xml.XmlNode xn)
        {
            this.FromXml(xn);
        }

        public BindingList<KeyboardInput> GazeEnterInputs
        {
            get
            {
                return this.gazeEnterInputs;
            }
        }

        public BindingList<KeyboardInput> GazeExitInputs
        {
            get
            {
                return this.gazeExitInputs;
            }
        }

        public void SimulateGazeEnterInputs()
        {
            this.SimulateKeys(this.gazeEnterInputs);
        }

        public void SimulateGazeExitInputs()
        {
            this.SimulateKeys(this.gazeExitInputs);
        }

        private void SimulateKeys(BindingList<KeyboardInput> kil)
        {
            foreach (KeyboardInput ki in kil)
            {
                if (ki.KeyOperation == KeyOperation.KeyDown)
                {
                    inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                }
                else if (ki.KeyOperation == KeyOperation.KeyUp)
                {
                    inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                }
                else if (ki.KeyOperation == KeyOperation.KeyPress)
                {
                    inputSimulator.Keyboard.KeyPress(ki.VirtualKey);
                }
                else if (ki.KeyOperation == KeyOperation.KeyToggle)
                {
                    bool down = inputSimulator.InputDeviceState.IsKeyDown(ki.VirtualKey);
                    if(down)
                        inputSimulator.Keyboard.KeyUp(ki.VirtualKey);
                    else
                        inputSimulator.Keyboard.KeyDown(ki.VirtualKey);
                }
            }
        }

        #region XML Read/Write

        private void FromXml(System.Xml.XmlNode xn)
        {
            System.Xml.XmlNode n = xn.SelectSingleNode(".//GazeEnterInputs");
            foreach(System.Xml.XmlNode genin in n.ChildNodes)
            {
                KeyOperation ko;
                if(Enum.TryParse(genin.Name, out ko))
                {
                    VirtualKeyCode vkc;
                    if (Enum.TryParse(genin.InnerText, out vkc))
                    {
                        this.gazeEnterInputs.Add(new KeyboardInput(vkc, ko));
                    }
                }
            }

            n = xn.SelectSingleNode(".//GazeExitInputs");
            foreach (System.Xml.XmlNode gexin in n.ChildNodes)
            {
                KeyOperation ko;
                if (Enum.TryParse(gexin.Name, out ko))
                {
                    VirtualKeyCode vkc;
                    if (Enum.TryParse(gexin.InnerText, out vkc))
                    {
                        this.gazeExitInputs.Add(new KeyboardInput(vkc, ko));
                    }
                }
            }
        }

        public System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            
            System.Xml.XmlElement root = xmlDoc.CreateElement("KeyboardInputSimulator");

            System.Xml.XmlElement geni = xmlDoc.CreateElement("GazeEnterInputs");

            foreach(KeyboardInput ki in this.gazeEnterInputs)
            {
                System.Xml.XmlElement kie = xmlDoc.CreateElement(Enum.GetName(typeof(KeyOperation), ki.KeyOperation));
                kie.InnerText = ((int)ki.VirtualKey).ToString();
                geni.AppendChild(kie);
            }

            root.AppendChild(geni);

            System.Xml.XmlElement gexi = xmlDoc.CreateElement("GazeExitInputs");

            foreach (KeyboardInput ki in this.gazeExitInputs)
            {
                System.Xml.XmlElement kie = xmlDoc.CreateElement(Enum.GetName(typeof(KeyOperation), ki.KeyOperation));
                kie.InnerText = ((int)ki.VirtualKey).ToString();
                gexi.AppendChild(kie);
            }

            root.AppendChild(gexi);

            xmlDoc.AppendChild(root);

            return xmlDoc;
        }

        #endregion
    }
}
