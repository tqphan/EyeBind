using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public partial class GazePanel : UserControl
    {
        Color borderColor = Color.Empty;
        int borderWidth = 5;

        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
                PerformLayout();
            }
        }

        public GazePanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(borderWidth, borderWidth, Bounds.Width - borderWidth * 2, Bounds.Height - borderWidth * 2);
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        new public BorderStyle BorderStyle
        {
            get { return borderWidth == 0 ? BorderStyle.None : BorderStyle.FixedSingle; }
            set { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            base.OnPaintBackground(e);
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen p = new Pen(borderColor, borderWidth))
                {
                    Rectangle r = ClientRectangle;
                    r.Inflate(-Convert.ToInt32(borderWidth / 2.0), -Convert.ToInt32(borderWidth / 2.0));
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
            //SetDisplayRectLocation(_borderWidth, _borderWidth);
        }

        //Making hit test transparnt so the parent form can be moved by dragging in the form's client area
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTTRANSPARENT = -1;

            if (m.Msg == (int)WM_NCHITTEST)
                m.Result = (IntPtr)HTTRANSPARENT;
            else
                base.WndProc(ref m);
        }
    }
}
