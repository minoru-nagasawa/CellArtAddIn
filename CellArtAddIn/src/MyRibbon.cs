using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace CellArtAddIn
{
    public partial class MyRibbon
    {
        public void ChangeStatus(bool check)
        {
            showHideBtn.Checked = check;

            if (check)
            {
                showHideBtn.Label = "Hide";
            }
            else
            {
                showHideBtn.Label = "Show";
            }
        }

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void showHideBtn_Click(object sender, RibbonControlEventArgs e)
        {
            ChangeStatus(showHideBtn.Checked);
            if (showHideBtn.Checked)
            {
                Globals.ThisAddIn.CustomPanel.Visible = true;
            }
            else
            {
                Globals.ThisAddIn.CustomPanel.Visible = false;
            }
        }
    }
}
