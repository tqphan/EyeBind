using System;
using System.Drawing;
using System.Windows.Forms;

namespace EyeBind
{
    public class DockGazeRegionButton: Button
    {
        private Color prevBackColor;
        private Color prevMouseDownBackColor;
        private Color prevMouseOverBackColor;

        public DockGazeRegionButton()
        {
            this.prevBackColor = this.BackColor;
            this.prevMouseDownBackColor = this.FlatAppearance.MouseDownBackColor;
            this.prevMouseOverBackColor = this.FlatAppearance.MouseOverBackColor;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Dock = DockStyle.Fill;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.UnsetTransparent();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SetTransparent();
        }

        private void SetTransparent()
        {
            this.BackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void UnsetTransparent()
        {
            this.BackColor = this.prevBackColor;
            this.FlatAppearance.MouseDownBackColor = this.prevMouseDownBackColor;
            this.FlatAppearance.MouseOverBackColor = this.prevMouseOverBackColor;
        }
    }
}
