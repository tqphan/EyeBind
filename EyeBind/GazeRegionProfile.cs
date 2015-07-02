using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;

namespace EyeBind
{
    public class GazeRegionProfile: INotifyPropertyChanged
    {
        private BindingList<GazeRegion> grl = new BindingList<GazeRegion>();
        private const string defaultName = "Gaze Profile";
        private string name;
        private Keys hotkey = Keys.None;
        private EyeSetting leftEye = new EyeSetting();
        private EyeSetting rightEye = new EyeSetting();

        public BindingList<GazeRegion> Profile
        {
            get
            {
                return this.grl;
            }
        }

        public Keys Hotkey
        {
            get
            {
                return this.hotkey;
            }
            set
            {
                if (value != this.hotkey)
                {
                    this.hotkey = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public EyeSetting LeftEyeSetting
        {
            get
            {
                return this.leftEye;
            }
        }

        public EyeSetting RightEyeSetting
        {
            get
            {
                return this.rightEye;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string DisplayName
        {
            get
            {
                if(this.hotkey == Keys.None)
                    return this.name;
                else
                    return (this.name + " (" + this.hotkey.ToString() + " )");
            }
        }

        public GazeRegionProfile()
            : base()
        {
            this.grl.Clear();
            this.name = string.Empty;
        }

        public GazeRegionProfile(XmlNode xn)
            : this()
        {
            this.FromXml(xn);
        }

        public void AddGazeRegion(GazeRegion gr)
        {
            this.grl.Add(gr);
        }

        public void ShowGazeRegions()
        {
            foreach (GazeRegion gr in this.grl)
            {
                gr.Show();
            }
        }

        public void HideGazeRegions()
        {
            foreach (GazeRegion gr in this.grl)
            {
                gr.Hide();
            }
        }

        public void ShowAndEnableGazeRegions()
        {
            foreach(GazeRegion gr in this.grl)
            {
                gr.Show();
                gr.GazeEnabled = true;
            }
        }

        public void HideAndDisableGazeRegions()
        {
            foreach (GazeRegion gr in this.grl)
            {
                gr.Hide();
                gr.GazeEnabled = false;
            }
        }

        public void RemoveGazeRegions()
        {
            foreach (GazeRegion gr in this.grl)
            {
                gr.Close();
            }
        }

        #region XML Read/Write
        private void FromXml(XmlNode xn)
        {
            try
            {
                this.Name = xn.Attributes["Name"].Value;
            }
            catch
            {
                this.Name = defaultName;
            }

            try
            {
                Keys k;
                if (Enum.TryParse(xn.Attributes["Hotkey"].Value, out k))
                {
                    this.Hotkey = k;
                }
            }
            catch
            {
                this.Hotkey = Keys.None;
            }
            
            XmlNodeList grn = xn.SelectNodes(".//GazeRegion"); 
            foreach(XmlNode n in grn)
            {
                this.grl.Add(new GazeRegion(n));
            }

            try
            {
                XmlNode len = xn.SelectSingleNode(".//LeftEye/Blink");
                leftEye = new EyeSetting(len);
            }
            catch (Exception)
            {
                leftEye = new EyeSetting();
            }

            try
            {
                XmlNode ren = xn.SelectSingleNode(".//RightEye/Blink");
                rightEye = new EyeSetting(ren);
            }
            catch (Exception)
            {
                rightEye = new EyeSetting();
            }
        }

        public XmlDocument ToXml()
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateElement("GazeRegionProfile"));
            xmlDoc.DocumentElement.SetAttribute("Name", this.Name);
            xmlDoc.DocumentElement.SetAttribute("Hotkey", ((int)this.hotkey).ToString());
            
            foreach (GazeRegion gr in this.grl)
            {
                XmlDocument xd = gr.ToXml();
                XmlDocumentFragment xfrag = xmlDoc.CreateDocumentFragment();
                xfrag.InnerXml = xd.OuterXml;
                xmlDoc.DocumentElement.AppendChild(xfrag);
            }

            XmlElement le = xmlDoc.CreateElement("LeftEye");
            XmlDocument led = leftEye.ToXml();
            XmlDocumentFragment lexfrag = xmlDoc.CreateDocumentFragment();
            lexfrag.InnerXml = led.OuterXml;
            le.AppendChild(lexfrag);
            xmlDoc.DocumentElement.AppendChild(le);

            XmlElement re = xmlDoc.CreateElement("RightEye");
            XmlDocument red = rightEye.ToXml();
            XmlDocumentFragment rexfrag = xmlDoc.CreateDocumentFragment();
            rexfrag.InnerXml = red.OuterXml;
            re.AppendChild(rexfrag);
            xmlDoc.DocumentElement.AppendChild(re);

            return xmlDoc;
        }
        #endregion

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
    }
}
