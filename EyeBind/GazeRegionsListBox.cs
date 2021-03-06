﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EyeBind
{
    public class GazeRegionsListBox : ListBox
    {
        public bool RemoveSelectedGazeRegion()
        {
            if (this.SelectedIndex > -1)
            {
                try
                {
                    BindingList<GazeRegion> grl = this.DataSource as BindingList<GazeRegion>; 
                    if (grl == null)
                        return false;

                    grl[this.SelectedIndex].Close();
                    grl.RemoveAt(this.SelectedIndex);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool AddGazeRegion()
        {
            try
            {
                BindingList<GazeRegion> grl = this.DataSource as BindingList<GazeRegion>;
                if (grl == null)
                    return false;

                GazeRegion gr = new GazeRegion();
                gr.RegionName = "Gaze Region";
                gr.GazeEnabled = true;
                gr.Show();
                grl.Add(gr);
                this.SelectedIndex = this.Items.Count - 1;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditSelectedGazeRegion()
        {
            if (this.SelectedIndex > -1)
            {
                try
                {
                    BindingList<GazeRegion> grl = this.DataSource as BindingList<GazeRegion>;
                    if (grl == null)
                        return false;
                    using (GazeRegionEditor gre = new GazeRegionEditor(grl[this.SelectedIndex]))
                    {
                        bool resumeSimulationAfter;
                        Form f = FindForm();
                        EyeBindMainForm ebmf = f as EyeBindMainForm;
                        if (ebmf == null)
                            return false;

                        if(ebmf.GetSimulationState())
                        {
                            resumeSimulationAfter = false;
                        }
                        else
                        {
                            resumeSimulationAfter = true;
                            ebmf.SetSimulationState(true);
                        }

                        gre.ShowDialog();
                        gre.Dispose();
                        this.DataSource = null;
                        this.DataSource = grl;
                        this.DisplayMember = "RegionName";

                        if(resumeSimulationAfter)
                        {
                            ebmf.SetSimulationState(false);
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool CloneSelectedGazeRegion()
        {
            if (this.SelectedIndex > -1)
            {
                try
                {
                    BindingList<GazeRegion> grl = this.DataSource as BindingList<GazeRegion>;
                    if (grl == null)
                        return false;

                    GazeRegion gr = grl[this.SelectedIndex].Clone();
                    gr.GazeEnabled = true;
                    gr.Show();
                    grl.Add(gr);
                    this.SelectedIndex = this.Items.Count - 1;
                    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);

            int index = this.IndexFromPoint(e.Location);
            if(index == this.SelectedIndex && index > -1)
            {
                try
                {
                    BindingList<GazeRegion> grl = this.DataSource as BindingList<GazeRegion>;
                    if (grl != null)
                        grl[this.SelectedIndex].BringToFront();
                }
                catch
                {

                }
            }
        }
    }
}
