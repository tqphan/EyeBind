using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace EyeBind
{
    public class ProfilesComboBox : ComboBox
    {
        public bool ShowSelectedProfile()
        {
            if (this.SelectedIndex > -1)
            {
                try
                {
                    BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;

                    if (grfl == null)
                        return false;

                    grfl[this.SelectedIndex].ShowGazeRegions();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool HideSelectedProfile()
        {
            if (this.SelectedIndex > -1)
            {
                try
                {
                    BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;

                    if (grfl == null)
                        return false;

                    grfl[this.SelectedIndex].HideGazeRegions();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool RemoveSelectedProfile()
        {
            if(this.SelectedIndex > 0)
            {
                try
                {
                    BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;

                    if (grfl == null)
                        return false;

                    grfl[this.SelectedIndex].RemoveGazeRegions();
                    grfl.RemoveAt(this.SelectedIndex);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            //System.Media.SystemSounds.Beep.Play();
            return false;
        }

        public bool AddProfile()
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                int index = this.FindStringExact(this.Text);
                if (index > -1)
                {
                    this.SelectedIndex = index;
                }
                else
                {
                    try
                    {
                        GazeRegionProfile grp = new GazeRegionProfile();
                        grp.Name = this.Text;
                        BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;
                        if (grfl == null)
                            return false;

                        grfl.Add(grp);

                        //select last item
                        if (this.Items.Count > 0)
                            this.SelectedIndex = this.Items.Count - 1;

                        return true;
                    }
                    catch
                    {
                        
                    }

                }
            }

            //System.Media.SystemSounds.Beep.Play();
            return false;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (this.SelectedIndex != -1)
            {
                Form f = FindForm();
                if(f is EyeBindMainForm == false)
                    return;

                EyeBindMainForm ebmf = f as EyeBindMainForm;
                if (ebmf == null)
                    return;

                for (int i = 0; i < ebmf.ProfilesList.Count; i++)
                {
                    if (i == this.SelectedIndex)
                    {
                        ebmf.ProfilesList[i].ShowAndEnableGazeRegions();
                        ebmf.GazeRegionsListBox.DataSource = null;
                        ebmf.GazeRegionsListBox.DataSource = ebmf.ProfilesList[i].Profile;
                        ebmf.GazeRegionsListBox.DisplayMember = "RegionName";
                    }
                    else
                    {
                        ebmf.ProfilesList[i].HideAndDisableGazeRegions();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys k)
        {
            if (k == Keys.Enter || k == Keys.Return)
            {
                if(!string.IsNullOrEmpty(this.Text))
                {
                    this.AddProfile();
                }                
                return true;
            }

            return base.ProcessCmdKey(ref msg, k);
        }
    }
}
