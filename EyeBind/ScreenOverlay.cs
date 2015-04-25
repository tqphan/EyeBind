using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.EyeX.Framework;

namespace EyeBind
{
    public partial class ScreenOverlay : Form
    {
        private Point gazePoint = new Point();
        private const int radiusBlack = 50;
        private const int radiusWhite = 52;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        public ScreenOverlay()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetBorderlessFullScreen();
            Program.GazePointDataStream.Next += GazePointDataStream_Next;
        }

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            base.OnClosing(e);
            Program.GazePointDataStream.Next -= GazePointDataStream_Next;
        }

        private void GazePointDataStream_Next(object sender, EyeXFramework.GazePointEventArgs e)
        {
            gazePoint.X = (int)e.X;
            gazePoint.Y = (int)e.Y;
            this.Invalidate();
        }

        private void ScreenOverlay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(Pens.Black, gazePoint.X - radiusBlack / 2, gazePoint.Y - radiusBlack / 2, radiusBlack, radiusBlack);
            e.Graphics.DrawEllipse(Pens.White, gazePoint.X - radiusWhite / 2, gazePoint.Y - radiusWhite / 2, radiusWhite, radiusWhite);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }

        protected void SetBorderlessFullScreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }

        protected void UnSetBorderlessFullScreen()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;

                //p.ExStyle |= 0x80000 | 0x20;

                return p;
            }
        }
    }
}
