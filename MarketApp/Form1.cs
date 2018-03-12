using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketApp
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tileNavPane1.Show();
        
        }

     
 

        private void navigationPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navigationPage1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void navigationPage1_Click(object sender, EventArgs e)
        {

        }

        private void navigationPage1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {

        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {

        }

        private void NewEntryBtn_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {

        }

        private void TileNewPatti_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Pattientryfrm pef = new Pattientryfrm();
            //pef.Parent = this;
            pef.Show();
            TileNewPatti.Enabled = false;
        }

        private void TileNewFarmer_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

            FarmerFrm ff = new FarmerFrm();
           // ff.MdiParent = this;
            ff.Show();
            TileNewFarmer.Enabled = false;

        }

        private void TilaeNewCustomer_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            CustomerFrm cf = new CustomerFrm();
             //   cf.MdiParent=this;
            cf.Show();
            TilaeNewCustomer.Enabled = false;
        }

        private void TileNewCommodity_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            commiditiesadd ca = new commiditiesadd();
          //  ca.MdiParent = this;
            ca.Show();
            TileNewCommodity.Enabled = false;
        }

        private void TileCustomerpay_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            custmreceipt cr = new custmreceipt();
            cr.Show();
            TileCustomerpay.Enabled = false;

        }

        private void TileFarmerpay_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FarmerPayment fp = new FarmerPayment();
            fp.Show();
            TileFarmerpay.Enabled = false;

        }

        

       
    }
}
