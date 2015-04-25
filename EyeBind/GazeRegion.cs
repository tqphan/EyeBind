using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using EyeBind.Properties;

namespace EyeBind
{
    #region structs
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public UInt32 flags;
    }

    public struct POINT
    {
        public int x;
        public int y;
    }

    public struct MinMaxInfo
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }
    #endregion

    public class GazeRegion : Form, INotifyPropertyChanged
    {
        #region Private members

        private bool inMovesize = false;
        private bool inMovesizeLoop = false;

        private bool gazeEnabled;

        private bool hasGaze = false;
        private bool activated = false;

        private Color gazeEnterColor = Color.Empty;
        private Color gazeExitColor = Color.Empty;
        private readonly Color gazeEnterColorDefault = Color.LightSkyBlue;
        private readonly Color gazeExitColorDefault = Color.Transparent;

        private Color gazeActivationColor = Color.Empty;
        private Color gazeDeactivationColor = Color.Empty;
        private readonly Color gazeActivationColorDefault = Color.LightBlue;
        private readonly Color gazeDeactivationColorDefault = Color.Transparent;

        private int activationDelay;
        private int deactivationDelay;

        private double gazeEnterTimestamp;
        private double gazeExitTimestamp;

        private int insideDuration;
        private int outsideDuration;

        private KeyboardInputSimulator keyboardInputSimulator = new KeyboardInputSimulator();
        private GazePanel gazePanel = new GazePanel();

        #endregion

        #region Constructors
        public GazeRegion(): base()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.TitleBar = false;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.Opacity = 1.00;
            this.DragMove = true;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.RegionName = "Gaze Region";

            this.GazeEnterColor = gazeEnterColorDefault;
            this.GazeExitColor = gazeExitColorDefault;
            this.GazeActivationColor = gazeActivationColorDefault;
            this.GazeDeactivationColor = gazeDeactivationColorDefault;

            this.Controls.Add(this.gazePanel);
        }

        public GazeRegion(System.Xml.XmlNode xn): this()
        {
            this.FromXml(xn);
        }
        #endregion

        public GazeRegion Clone()
        {
            GazeRegion clone = new GazeRegion();
            clone.RegionName = this.RegionName;

            clone.Top = this.Top;
            clone.Left = this.Left;
            clone.Width = this.Width;
            clone.Height = this.Height;
            
            clone.Opacity = this.Opacity;
            
            clone.TopMost = this.TopMost;
            
            clone.GazeEnterColor = this.GazeEnterColor;
            clone.GazeExitColor = this.GazeExitColor;
            clone.GazeActivationColor = this.GazeActivationColor;
            
            clone.GazeDeactivationColor = this.GazeDeactivationColor;
            clone.ActivationDelay = this.ActivationDelay;
            clone.DeactivationDelay = this.DeactivationDelay;

            return clone;
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
        public string RegionName
        {
            get;
            set;
        }

        public bool GazeEnabled
        {
            get
            {
                return this.gazeEnabled;
            }
            set
            {
                this.gazeEnabled = value;
            }
        }

        public BindingList<KeyboardInput> GazeEnterInputs
        {
            get
            {
                return this.keyboardInputSimulator.GazeEnterInputs;
            }
        }

        public BindingList<KeyboardInput> GazeExitInputs
        {
            get
            {
                return this.keyboardInputSimulator.GazeExitInputs;
            }
        }

        public static bool InputSimulationEnable
        {
            get;
            set;
        }

        public bool DragMove
        {
            get;
            set;
        }

        public bool TitleBar
        {
            set 
            {
                this.ControlBox = value;
                if(value)
                {
                    this.Text = this.RegionName;
                }
                else
                {
                    this.Text = string.Empty;
                }
            }

            get
            {
                return this.ControlBox;
            }
        }

        /// <summary>
        /// Gets or sets the color used to indicate gaze point enter.
        /// </summary>
        public Color GazeEnterColor
        {
            get
            {
                return this.gazeEnterColor;
            }
            set
            {
                if (value != this.gazeEnterColor)
                {
                    this.gazeEnterColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color used to indicate gaze point exit.
        /// </summary>
        public Color GazeExitColor
        {
            get
            {
                return this.gazeExitColor;
            }
            set
            {
                if (value != this.gazeExitColor)
                {
                    this.gazeExitColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color used to indicate gaze activation.
        /// </summary>
        public Color GazeActivationColor
        {
            get
            {
                return this.gazeActivationColor;
            }
            set
            {
                if (value != this.gazeActivationColor)
                {
                    this.gazeActivationColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the color used to indicate gaze deactivation.
        /// </summary>
        public Color GazeDeactivationColor
        {
            get
            {
                return this.gazeDeactivationColor;
            }
            set
            {
                if (value != this.gazeDeactivationColor)
                {
                    this.gazeDeactivationColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the region's activation delay time in miliseconds.
        /// </summary>
        public int ActivationDelay
        {
            get
            {
                return this.activationDelay;
            }
            set
            {
                if (value != this.activationDelay)
                {
                    this.activationDelay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the region's deactivation delay time in miliseconds.
        /// </summary>
        public int DeactivationDelay
        {
            get
            {
                return this.deactivationDelay;
            }
            set
            {
                if (value != this.deactivationDelay)
                {
                    this.deactivationDelay = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int ActivationCooldown
        {
            get;
            set;
        }

        #endregion

        #region Gaze data process/logic

        private void FixationDataStream_Next(object sender, EyeXFramework.FixationEventArgs e)
        {
            if (this.GazeEnabled)
            {
                this.ProcessGazeDataStream(e.X, e.Y, e.Timestamp);
            }
        }

        private void GazePointDataStream_Next(object sender, EyeXFramework.GazePointEventArgs e)
        {

        }

        private void ProcessGazeDataStream(double x, double y, double timeStamp)
        {
            Rectangle rect = new Rectangle(this.Left, this.Top, this.Width, this.Height);
            Point point = new Point((int)x, (int)y);

            this.ProcessGazePointData(point, rect, timeStamp);
        }

        private void ProcessGazePointData(Point gazePoint, Rectangle rect, double timeStamp)
        {
            //hit test the region's rectangle with the gaze point 
            if (rect.Contains(gazePoint))
            {
                if(!this.hasGaze)
                {
                    //Gaze point has now entered the region
                    this.hasGaze = true;
                    this.OnGazeEnter(timeStamp);
                }
                else
                {
                    //Gaze point still inside the region
                    this.OnGazeRemainInside(timeStamp);
                }
            }
            else
            {
                if(this.hasGaze)
                {
                    //Gaze point has now exited the region
                    this.hasGaze = false;
                    this.OnGazeExit(timeStamp);
                }
                else
                {
                    //Gaze point still outside the region
                    this.OnGazeRemainOutside(timeStamp);
                }
            }
        }

        private void OnGazeEnter(double timeStamp)
        {
            this.gazeEnterTimestamp = timeStamp;
            this.gazePanel.BorderColor = this.GazeEnterColor;

            if(!this.activated && this.activationDelay < 1)
            {
                this.OnGazeActivation();
            }
        }

        private void OnGazeExit(double timeStamp)
        {
            this.gazeExitTimestamp = timeStamp;
            this.gazePanel.BorderColor = this.GazeExitColor;

            if (this.activated && this.deactivationDelay < 1)
            {
                this.OnGazeDeactivation();
            }
        }

        private void OnGazeRemainInside(double timeStamp)
        {
            this.insideDuration = (int)(timeStamp - this.gazeEnterTimestamp);
            if(!this.activated)
            {
                if(this.insideDuration > this.activationDelay)
                {
                    this.OnGazeActivation();
                }
            }
        }
        private void OnGazeRemainOutside(double timeStamp)
        {
            this.outsideDuration = (int)(timeStamp - this.gazeExitTimestamp);
            if (this.activated)
            {
                if (this.outsideDuration > this.deactivationDelay)
                {
                    this.OnGazeDeactivation();
                }
            }
        }

        private void OnGazeActivation()
        {
            this.activated = true;

            if (!Settings.Default.InputSimulationPaused)
            {
                this.keyboardInputSimulator.SimulateGazeEnterInputs();
            }

            this.gazePanel.BackColor = this.GazeActivationColor;

            if(Settings.Default.ActivationSoundEnabled)
            {
                GazeSoundPlayer.Play();
            }
        }

        private void OnGazeDeactivation()
        {
            this.activated = false;

            if (!Settings.Default.InputSimulationPaused)
            {
                this.keyboardInputSimulator.SimulateGazeExitInputs();
            }

            this.gazePanel.BackColor = this.GazeDeactivationColor;

            if (Settings.Default.DeactivationSoundEnabled)
            {
                GazeSoundPlayer.Play();
            }
        }

        #endregion

        #region Override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Program.FixationDataStream.Next += FixationDataStream_Next;
        }


        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            base.OnClosing(e);
            Program.FixationDataStream.Next -= FixationDataStream_Next;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        #endregion

        #region XML Read/Write

        private void FromXml(System.Xml.XmlNode xn)
        {
            int i = 0;
            double d = 1.0;

            System.Xml.XmlNode n = xn.SelectSingleNode(".//Name");
            this.RegionName = n.InnerText;

            n = xn.SelectSingleNode(".//Top");
            if (int.TryParse(n.InnerText, out i))
            {
                this.Top = i;
            }
            i = 0;

            n = xn.SelectSingleNode(".//Left");
            if (int.TryParse(n.InnerText, out i))
            {
                this.Left = i;
            }
            i = 0;

            n = xn.SelectSingleNode(".//Width");
            if (int.TryParse(n.InnerText, out i))
            {
                this.Width = i;
            }
            i = 0;

            n = xn.SelectSingleNode(".//Height");
            if (int.TryParse(n.InnerText, out i))
            {
                this.Height = i;
            }
            i = 0;

            n = xn.SelectSingleNode(".//TopMost");
            bool b;
            if (bool.TryParse(n.InnerText, out b))
            {
                this.TopMost = b;
            }

            n = xn.SelectSingleNode(".//Opacity");
            if(double.TryParse(n.InnerText, out d))
            {
                this.Opacity = d;
            }
            d = 1.0;

            n = xn.SelectSingleNode(".//GazeEnterColor");
            try
            {
                this.GazeEnterColor = ColorTranslator.FromHtml(n.InnerText);
            }
            catch
            {
                this.GazeEnterColor = gazeEnterColorDefault;
            }

            n = xn.SelectSingleNode(".//GazeExitColor");
            try
            {
                this.GazeExitColor = ColorTranslator.FromHtml(n.InnerText);
            }
            catch
            {
                this.GazeExitColor = gazeExitColorDefault;
            }

            n = xn.SelectSingleNode(".//GazeActivationColor");
            try
            {
                this.GazeActivationColor = ColorTranslator.FromHtml(n.InnerText);
            }
            catch
            {
                this.GazeActivationColor = gazeActivationColorDefault;
            }

            n = xn.SelectSingleNode(".//GazeDeactivationColor");
            try
            {
                this.GazeDeactivationColor = ColorTranslator.FromHtml(n.InnerText);
            }
            catch
            {
                this.GazeDeactivationColor = gazeDeactivationColorDefault;
            }

            n = xn.SelectSingleNode(".//ActivationDelay");
            if (int.TryParse(n.InnerText, out i))
            {
                if(i >= 0)
                    this.ActivationDelay = i;
                else
                    this.ActivationDelay = 0;
            }
            i = 0;

            n = xn.SelectSingleNode(".//DeactivationDelay");
            if (int.TryParse(n.InnerText, out i))
            {
                if (i >= 0)
                    this.DeactivationDelay = i;
                else
                    this.DeactivationDelay = 0;
            }
            i = 0;

            n = xn.SelectSingleNode(".//KeyboardInputSimulator");
            this.keyboardInputSimulator = new KeyboardInputSimulator(n);
        }

        public System.Xml.XmlDocument ToXml()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

            System.Xml.XmlElement root = xmlDoc.CreateElement("GazeRegion");

            System.Xml.XmlElement name = xmlDoc.CreateElement("Name");
            name.InnerText = this.RegionName;
            root.AppendChild(name);

            System.Xml.XmlElement top = xmlDoc.CreateElement("Top");
            top.InnerText = this.Top.ToString();
            root.AppendChild(top);

            System.Xml.XmlElement left = xmlDoc.CreateElement("Left");
            left.InnerText = this.Left.ToString();
            root.AppendChild(left);

            System.Xml.XmlElement width = xmlDoc.CreateElement("Width");
            width.InnerText = this.Width.ToString();
            root.AppendChild(width);

            System.Xml.XmlElement height = xmlDoc.CreateElement("Height");
            height.InnerText = this.Height.ToString();
            root.AppendChild(height);

            System.Xml.XmlElement topMost = xmlDoc.CreateElement("TopMost");
            topMost.InnerText = this.TopMost.ToString();
            root.AppendChild(topMost);

            System.Xml.XmlElement opacity = xmlDoc.CreateElement("Opacity");
            opacity.InnerText = this.Opacity.ToString();
            root.AppendChild(opacity);

            System.Xml.XmlElement gazeEnterColor = xmlDoc.CreateElement("GazeEnterColor");
            gazeEnterColor.InnerText = String.Format("#{0:X2}{1:X2}{2:X2}", this.GazeEnterColor.R, this.GazeEnterColor.G, this.GazeEnterColor.B);
            root.AppendChild(gazeEnterColor);

            System.Xml.XmlElement gazeExitColor = xmlDoc.CreateElement("GazeExitColor");
            gazeExitColor.InnerText = String.Format("#{0:X2}{1:X2}{2:X2}", this.GazeExitColor.R, this.GazeExitColor.G, this.GazeExitColor.B);
            root.AppendChild(gazeExitColor);

            System.Xml.XmlElement gazeActivationColor = xmlDoc.CreateElement("GazeActivationColor");
            gazeActivationColor.InnerText = String.Format("#{0:X2}{1:X2}{2:X2}", this.GazeActivationColor.R, this.GazeActivationColor.G, this.GazeActivationColor.B);
            root.AppendChild(gazeActivationColor);

            System.Xml.XmlElement gazeDeactivationColor = xmlDoc.CreateElement("GazeDeactivationColor");
            gazeDeactivationColor.InnerText = String.Format("#{0:X2}{1:X2}{2:X2}", this.GazeDeactivationColor.R, this.GazeDeactivationColor.G, this.GazeDeactivationColor.B);
            root.AppendChild(gazeDeactivationColor);

            System.Xml.XmlElement activationDelay = xmlDoc.CreateElement("ActivationDelay");
            activationDelay.InnerText = this.ActivationDelay.ToString();
            root.AppendChild(activationDelay);

            System.Xml.XmlElement deactivationDelay = xmlDoc.CreateElement("DeactivationDelay");
            deactivationDelay.InnerText = this.DeactivationDelay.ToString();
            root.AppendChild(deactivationDelay);

            System.Xml.XmlDocument xd = this.keyboardInputSimulator.ToXml();
            System.Xml.XmlDocumentFragment xfrag = xmlDoc.CreateDocumentFragment();
            xfrag.InnerXml = xd.OuterXml;
            root.AppendChild(xfrag);

            xmlDoc.AppendChild(root);

            return xmlDoc;
        }

        #endregion

        //protected override System.Windows.Forms.CreateParams CreateParams
        //{
        //    get
        //    {
        //        const int WS_DLGFRAME = 0x00400000;
        //        const int WS_THICKFRAME = 0x00040000;
        //        const int WS_POPUP = unchecked((int)0x80000000);

        //        const int WS_OVERLAPPED = 0x00000000;
        //        const int WS_CAPTION = 0x00C00000;
        //        const int WS_SYSMENU = 0x00080000;
        //        const int WS_MAXIMIZEBOX = 0x00010000;
        //        const int WS_MINIMIZEBOX = 0x00020000;
        //        const int WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
        //        const int WS_SIZEBOX = 0x00040000;


        //        System.Windows.Forms.CreateParams cp = base.CreateParams;
        //        cp.Height = 30;
        //        cp.Width = 30;
        //        //cp.Style = 0;
        //        //cp.Style |= WS_OVERLAPPEDWINDOW;
        //        //cp.Style ^= WS_THICKFRAME;
        //        //cp.Style |= WS_DLGFRAME | WS_POPUP;
        //        return cp;
        //    }
        //}

        #region WndProc

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTCLIENT = 0x1;
            const int HTCAPTION = 0x2;
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            const int WM_CAPTURECHANGED = 0x0215;
            const int WM_WINDOWPOSCHANGING = 0x0046;
            const int SWP_NOMOVE = 0x0002;
            const int WM_GETMINMAXINFO = 0x0024;


            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if(this.DragMove)
                    {
                        base.WndProc(ref m);
                        if ((int)m.Result == HTCLIENT)
                            m.Result = (IntPtr)HTCAPTION;
                        return;
                    }
                    break;

                case WM_ENTERSIZEMOVE:
                    inMovesize = true;
                    inMovesizeLoop = false;
                    break;

                case WM_EXITSIZEMOVE:
                    inMovesize = false;
                    inMovesizeLoop = false;
                    break;

                case WM_CAPTURECHANGED:
                    inMovesizeLoop = inMovesize;
                    break;

                case WM_WINDOWPOSCHANGING:
                    WINDOWPOS windowPos = (WINDOWPOS)m.GetLParam(typeof(WINDOWPOS));
                    
                    if (inMovesizeLoop)
                    {
                        windowPos.flags |= SWP_NOMOVE;
                    }

                    System.Runtime.InteropServices.Marshal.StructureToPtr(windowPos, m.LParam, true);
                    break;

                case WM_GETMINMAXINFO:
                    base.WndProc(ref m);
                    MinMaxInfo minMaxInfo = (MinMaxInfo)m.GetLParam(typeof(MinMaxInfo));
                    minMaxInfo.ptMinTrackSize.x = this.MinimumSize.Width;
                    minMaxInfo.ptMinTrackSize.y = this.MinimumSize.Height;
                    System.Runtime.InteropServices.Marshal.StructureToPtr(minMaxInfo, m.LParam, true);
                    return;
            }

            base.WndProc(ref m);
        }

        #endregion
    }
}
