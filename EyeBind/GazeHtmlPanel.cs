using System;
using System.Drawing;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace EyeBind
{
    public class GazeHtmlPanel : HtmlPanel
    {
        public GazeHtmlPanel()
        {
            this.IsContextMenuEnabled = false;
            this.IsSelectionEnabled = false;
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = false;
        }

        protected override void AdjustFormScrollbars(bool displayScrollbars)
        {
            base.AdjustFormScrollbars(false);
        }

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
