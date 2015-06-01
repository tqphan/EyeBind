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
            
            XmlNodeList grn = xn.ChildNodes; 
            foreach(XmlNode n in grn)
            {
                this.grl.Add(new GazeRegion(n));
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
