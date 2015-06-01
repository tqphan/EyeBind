using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace EyeBind
{
    public class ProfilesComboBox : ComboBox
    {
        public ProfilesComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

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
            if (this.SelectedIndex > 0)
            {
                try
                {
                    BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;

                    if (grfl == null)
                        return false;

                    grfl[this.SelectedIndex].RemoveGazeRegions();
                    grfl.RemoveAt(this.SelectedIndex);

                    //select first item
                    if (this.Items.Count >= 0)
                        this.SelectedIndex = 0;

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool AddProfile()
        {
            try
            {
                using (ProfileEditor pe = new ProfileEditor("New Profile", Keys.None))
                {
                    var result = pe.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(pe.ProfileName))
                        {
                            GazeRegionProfile grp = new GazeRegionProfile();
                            grp.Name = pe.ProfileName;
                            grp.Hotkey = pe.Hotkey;
                            BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;
                            if (grfl == null)
                                return false;

                            grfl.Add(grp);

                            //select last item
                            if (this.Items.Count > 0)
                                this.SelectedIndex = this.Items.Count - 1;

                            return true;
                        }
                    }
                    pe.Dispose();
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public bool EditSelectedProfile()
        {
            if (this.SelectedIndex > -1)
            {
                BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;
                if (grfl == null)
                    return false;

                string name = grfl[this.SelectedIndex].Name;
                Keys key = grfl[this.SelectedIndex].Hotkey;
                using (ProfileEditor pe = new ProfileEditor(name, key))
                {
                    var result = pe.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        grfl[this.SelectedIndex].Name = pe.ProfileName;
                        grfl[this.SelectedIndex].Hotkey = pe.Hotkey;

                        Form f = FindForm();
                        if (f is EyeBindMainForm == false)
                            return false;

                        EyeBindMainForm ebmf = f as EyeBindMainForm;
                        if (ebmf == null)
                            return false;

                        this.DataSource = null;
                        this.DataSource = ebmf.ProfilesList;
                        this.DisplayMember = "DisplayName";
                    }
                    pe.Dispose();
                }
            }
            return false;
        }

        public bool CloneSelectedProfille()
        {
            if (this.SelectedIndex > -1)
            {
                BindingList<GazeRegionProfile> grfl = this.DataSource as BindingList<GazeRegionProfile>;
                if (grfl == null)
                    return false;

                GazeRegionProfile grp = grfl[this.SelectedIndex];

                List<string> regionNames = new List<string>();

                foreach (GazeRegion gr in grp.Profile)
                {
                    regionNames.Add(gr.RegionName);
                }

                using (ProfileCloner pc = new ProfileCloner(regionNames, grp.Name))
                {
                    var result = pc.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        GazeRegionProfile ngrp = new GazeRegionProfile();

                        if (grp.Profile.Count == pc.RegionsToClone.Count)
                        {
                            for(int i = 0; i < grp.Profile.Count; i++)
                            {
                                if (pc.RegionsToClone[i])
                                    ngrp.Profile.Add(grp.Profile[i].Clone());
                            }
                        }
                        else
                        {
                            pc.Dispose();
                            return false;
                        }

                        ngrp.Name = pc.ProfileName;
                        ngrp.Hotkey = pc.Hotkey;
                        grfl.Add(ngrp);

                        //select last item
                        if (this.Items.Count > 0)
                            this.SelectedIndex = this.Items.Count - 1;
                    }

                    pc.Dispose();
                }
            }
            return false;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (this.SelectedIndex != -1)
            {
                Form f = FindForm();
                if (f is EyeBindMainForm == false)
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
    }
}
