using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public class KeyRecorderDataGridView : DataGridView
    {
        public KeyRecorderDataGridView()
        {
            this.Dock = DockStyle.Fill;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
            this.RowHeadersVisible = false;
            this.ColumnHeadersVisible = false;
            //this.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            e.Handled = true;
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            e.IsInputKey = false;
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);
            if(this.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&e.RowIndex != -1)
            {
                this.Rows.RemoveAt(e.RowIndex);
            }
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            this.FirstDisplayedScrollingRowIndex = this.RowCount-1;
        }
    }
}
