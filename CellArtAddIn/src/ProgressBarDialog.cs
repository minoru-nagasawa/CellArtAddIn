using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellArtAddIn
{
    public partial class ProgressBarDialog : Form
    {
        private bool m_cancel = false;
        public bool IsCancelled
        {
            get
            {
                return m_cancel;
            }
        }
        public ProgressBarDialog()
        {
            InitializeComponent();
        }

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            m_cancel = true;
            this.Close();
        }
    }
}
