using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EyeBind
{
    public static class UpdateChecker
    {
        private const string xmlUrl = "https://raw.githubusercontent.com/tqphan/EyeBind/master/version.xml";

        public static bool Check()
        {
            using (XmlTextReader reader = new XmlTextReader(xmlUrl))
            {
                try
                {
                    string elementName = string.Empty;
                    reader.MoveToContent();
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "EyeBind"))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    elementName = reader.Name;
                                    break;
                                default:
                                    if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                                    {
                                        switch (elementName)
                                        {
                                            case "version":
                                                //_newVersion = new Version(reader.Value);
                                                break;
                                            case "url":
                                                //_releasePageURL = _reader.Value;
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                catch { }
            }

            return false;
        }
    }
}
