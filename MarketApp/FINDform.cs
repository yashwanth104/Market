using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MarketApp
{
    public partial class FINDform : DevExpress.XtraEditors.XtraForm
    {
        public FINDform()
        {
            InitializeComponent();
        }

        private void FINDform_Load(object sender, EventArgs e)
        {
            radioGroup1.EditValue = 0;
        }

        private void srch_Click(object sender, EventArgs e)
        {
            if (srchfield.Text == "")
            {
                MessageBox.Show("INALID ENTRY");
                return;
            }
            
            if ( Int32.Parse(radioGroup1.EditValue.ToString()) == 0)
            {
                Program.FindType = 1;
            }

            if (Int32.Parse(radioGroup1.EditValue.ToString()) == 1)
            {
                Program.FindType = 0;
            }
            Program.FindString = srchfield.Text;
            this.Close();
        }
    }
}