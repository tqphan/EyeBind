using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsInput.Native;

namespace EyeBind
{
    public class EyeSetting : INotifyPropertyChanged
    {
        protected bool enabled;
        protected BindingList<KeyboardInput> eyeCloseInputs = new BindingList<KeyboardInput>();
        protected BindingList<KeyboardInput> eyeOpenInputs = new BindingList<KeyboardInput>();
        protected int eyeCloseActivationDelay = 500;
        protected int eyeOpenActivationDelay = 500;

        public EyeSetting()
        {

        }

        public EyeSetting(System.Xml.XmlNode xn): this()
        {
            FromXml(xn);
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

        public bool Enabled
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
                    NotifyPropertyChanged();
                }
            }
        }

        public BindingList<KeyboardInput> EyeCloseInputs
        {
            get
            {
                return eyeCloseInputs;
            }
        }

        public BindingList<KeyboardInput> EyeOpenInputs
        {
            get
            {
                return eyeOpenInputs;
            }
        }

        public int EyeCloseActivationDelay
        {
            get
            {
                return eyeCloseActivationDelay;
            }
            set
            {
                if (value != eyeCloseActivationDelay)
                {
                    eyeCloseActivationDelay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int EyeOpenActivationDelay
        {
            get
            {
                return eyeOpenActivationDelay;
            }
            set
            {
                if (value != eyeOpenActivationDelay)
                {
                    eyeOpenActivationDelay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void FromXml(System.Xml.XmlNode xn)
        {
            bool be = false;
            System.Xml.XmlNode n = xn.SelectSingleNode(".//Enabled");
            if (bool.TryParse(n.InnerText, out be))
            {
                enabled = be;
            }

            int i;
            n = xn.SelectSingleNode(".//EyeCloseActivationDelay");
            if (int.TryParse(n.InnerText, out i))
            {
                if (i >= 0)
                    eyeCloseActivationDelay = i;
            }


            n = xn.SelectSingleNode(".//EyeCloseInputs");
            foreach (System.Xml.XmlNode lein in n.ChildNodes)
            {
                KeyOperation ko;
                if (Enum.TryParse(lein.Name, out ko))
                {
                    VirtualKeyCode vkc;
                    if (Enum.TryParse(lein.InnerText, out vkc))
                    {
                        eyeCloseInputs.Add(new KeyboardInput(vkc, ko));
                    }
                }
            }

            i = 0;
            n = xn.SelectSingleNode(".//EyeOpenActivationDelay");
            if (int.TryParse(n.InnerText, out i))
            {
                if (i >= 0)
                    eyeOpenActivationDelay = i;
            }

            n = xn.SelectSingleNode(".//EyeOpenInputs");
            foreach (System.Xml.XmlNode lein in n.ChildNodes)
            {
                KeyOperation ko;
                if (Enum.TryParse(lein.Name, out ko))
                {
                    VirtualKeyCode vkc;
                    if (Enum.TryParse(lein.InnerText, out vkc))
                    {
                        eyeOpenInputs.Add(new KeyboardInput(vkc, ko));
                    }
                }
            }
        }

        public System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            System.Xml.XmlElement root = xmlDoc.CreateElement("Blink");

            System.Xml.XmlElement bl = xmlDoc.CreateElement("Enabled");
            bl.InnerText = enabled.ToString();
            root.AppendChild(bl);

            System.Xml.XmlElement cdelay = xmlDoc.CreateElement("EyeCloseActivationDelay");
            cdelay.InnerText = eyeCloseActivationDelay.ToString();
            root.AppendChild(cdelay);

            System.Xml.XmlElement cinputs = xmlDoc.CreateElement("EyeCloseInputs");

            foreach (KeyboardInput ki in eyeCloseInputs)
            {
                System.Xml.XmlElement kie = xmlDoc.CreateElement(Enum.GetName(typeof(KeyOperation), ki.KeyOperation));
                kie.InnerText = ((int)ki.VirtualKey).ToString();
                cinputs.AppendChild(kie);
            }

            root.AppendChild(cinputs);

            System.Xml.XmlElement odelay = xmlDoc.CreateElement("EyeOpenActivationDelay");
            odelay.InnerText = eyeOpenActivationDelay.ToString();
            root.AppendChild(odelay);

            System.Xml.XmlElement oinputs = xmlDoc.CreateElement("EyeOpenInputs");

            foreach (KeyboardInput ki in eyeCloseInputs)
            {
                System.Xml.XmlElement kie = xmlDoc.CreateElement(Enum.GetName(typeof(KeyOperation), ki.KeyOperation));
                kie.InnerText = ((int)ki.VirtualKey).ToString();
                oinputs.AppendChild(kie);
            }

            root.AppendChild(oinputs);

            xmlDoc.AppendChild(root);

            return xmlDoc;
        }
    }
}
