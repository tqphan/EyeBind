using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EyeBind.Properties;

namespace EyeBind
{
    public class BlinkMonitor : INotifyPropertyChanged
    {
        #region Private

        private bool enabled;
        private Eye leftEye = new Eye() { Name = "LeftEye" };
        private Eye rightEye = new Eye() { Name = "RightEye" };

        #endregion

        public BlinkMonitor()
        {
        }

        public BlinkMonitor(System.Xml.XmlNode xn)
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

        #region Properties
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (value != this.enabled)
                {
                    this.enabled = value;

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

        public Eye LeftEye
        {
            get
            { 
                return this.leftEye;
            }
        }

        public Eye RightEye
        {
            get
            {
                return this.rightEye;
            }
        }

        #endregion

        private void EyePositionDataStream_Next(object sender, EyeXFramework.EyePositionEventArgs e)
        {
            if(Settings.Default.LeftEyeBlinkEnabled)
                this.leftEye.ProcessEye(e.LeftEye.IsValid, e.Timestamp);

            if (Settings.Default.RightEyeBlinkEnabled)
                this.rightEye.ProcessEye(e.RightEye.IsValid, e.Timestamp);
        }

        private void FromXml(System.Xml.XmlNode xn)
        {
            System.Xml.XmlNode n = xn.SelectSingleNode(".//LeftEye");
            this.leftEye = new Eye(n) { Name = "LeftEye" }; 

            n = xn.SelectSingleNode(".//RightEye");
            this.rightEye = new Eye(n){ Name = "RightEye" };

        }

        public System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            System.Xml.XmlElement root = xmlDoc.CreateElement("BlinkMonitor");

            System.Xml.XmlDocument le = this.leftEye.ToXml();
            System.Xml.XmlDocumentFragment lexfrag = xmlDoc.CreateDocumentFragment();
            lexfrag.InnerXml = le.OuterXml;
            root.AppendChild(lexfrag);

            System.Xml.XmlDocument re = this.rightEye.ToXml();
            System.Xml.XmlDocumentFragment rexfrag = xmlDoc.CreateDocumentFragment();
            rexfrag.InnerXml = re.OuterXml;
            root.AppendChild(rexfrag);

            xmlDoc.AppendChild(root);

            return xmlDoc;
        }
    }
}
