using System.ComponentModel;
using System.Windows.Forms;

namespace EyeBind
{
    public class GazeRegionProfile
    {
        private BindingList<GazeRegion> grl = new BindingList<GazeRegion>();
        private string name;
        private Keys hotkey = Keys.None;

        public BindingList<GazeRegion> Profile
        {
            get
            {
                return this.grl;
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

        public GazeRegionProfile()
            : base()
        {
            this.grl.Clear();
            this.name = string.Empty;
        }

        public GazeRegionProfile(System.Xml.XmlNode xn)
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

        private void FromXml(System.Xml.XmlNode xn)
        {
            this.Name = xn.Attributes["Name"].Value;
            
            System.Xml.XmlNodeList grn = xn.ChildNodes; 
            foreach(System.Xml.XmlNode n in grn)
            {
                this.grl.Add(new GazeRegion(n));
            }
        }

        public System.Xml.XmlDocument ToXml()
        {

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateElement("GazeRegionProfile"));
            xmlDoc.DocumentElement.SetAttribute("Name", this.Name);
            xmlDoc.DocumentElement.SetAttribute("Hotkey", ((int)this.hotkey).ToString());
            
            foreach (GazeRegion gr in this.grl)
            {
                System.Xml.XmlDocument xd = gr.ToXml();
                System.Xml.XmlDocumentFragment xfrag = xmlDoc.CreateDocumentFragment();
                xfrag.InnerXml = xd.OuterXml;
                xmlDoc.DocumentElement.AppendChild(xfrag);
            }

            return xmlDoc;
        }
    }
}
