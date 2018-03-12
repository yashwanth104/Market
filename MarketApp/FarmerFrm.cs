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
    public partial class FarmerFrm : DevExpress.XtraEditors.XtraForm
    {
        ADODB.Recordset frmr_tb = new ADODB.Recordset();
        int cpos = 0;
        string prename;
        public FarmerFrm()
        {
            InitializeComponent();
        }

        private void FarmerFrm_Load(object sender, EventArgs e)
        {
            frmr_tb.Open(@"select * from farmerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

            textid.ReadOnly = true;
            LockUnLockMe(true);
            if (frmr_tb.RecordCount > 0)
            {
                this.FillList();
                this.FillText();
                cpos = 1;
            }

           
        }


        private void emptyTxt()
        {
            textid.Text = "";
            textname.Text = "";
            textaddress.Text = "";
            textmobile.Text = "";

        }

        private void LockUnLockMe(bool stat)
        {
            textname.ReadOnly = stat;
            textaddress.ReadOnly = stat;
            textmobile.ReadOnly = stat;


        }
        private void FillText()
        {
            if (frmr_tb.RecordCount > 0)
            {
                textid.Text = frmr_tb.Fields["fID"].Value.ToString();
                textname.Text = frmr_tb.Fields["fNames"].Value.ToString();
                textaddress.Text = frmr_tb.Fields["address"].Value.ToString();
                textmobile.Text = frmr_tb.Fields["phn_num"].Value.ToString();

            }
        }
        private void GetData()
        {
            frmr_tb.Fields["fID"].Value = int.Parse(textid.Text);
            frmr_tb.Fields["fNames"].Value = textname.Text;
            frmr_tb.Fields["address"].Value = textaddress.Text;
            frmr_tb.Fields["phn_num"].Value = textmobile.Text;
        }
        private void FillList()
        {
            if (frmr_tb.RecordCount > 0)
            {
                while (frmr_tb.EOF == false)
                {
                    farmers_list.Items.Add(frmr_tb.Fields["fNames"].Value.ToString());
                    farmers_list.Update();
                    frmr_tb.MoveNext();
                }
                frmr_tb.MoveFirst();
            }
        }

        private void SetButton()
        {
            fnd.Enabled = true;
            nxt.Enabled = true;
            prev.Enabled = true;
            edt.Enabled = true;
            addcust.Enabled = true;
            fnd.Text = "&Find";
            nxt.Text = "&Next";
            prev.Text = "&Prev";
            edt.Text = "&Edit";
            addcust.Text = "&Add new Farmer";


        }




        private void prev_Click(object sender, EventArgs e)
        {
            if (cpos > 1)
            {
                frmr_tb.MovePrevious();
                this.FillText();
                cpos = cpos - 1;
            }

        }


        private void nxt_Click(object sender, EventArgs e)
        {

            if (frmr_tb.RecordCount > cpos)
            {
                frmr_tb.MoveNext();
                cpos = cpos + 1;
                this.FillText();


            }

        }

        private void edt_Click(object sender, EventArgs e)
        {
            if (edt.Text == "&Edit")
            {
                LockUnLockMe(false);
                addcust.Enabled = false;
                prev.Enabled = false;
                nxt.Enabled = false;

                fnd.Text = "&Cancel";
                edt.Text = "&Update";
                prename = textname.Text;
                return;
            }
            else if (edt.Text == "&Update")
            {
                if (textname.Text == "")
                {
                    XtraMessageBox.Show("Invaild Name");
                    return;
                }

                GetData();
                frmr_tb.Update();
                int rowlist = farmers_list.Items.Count;
                for (int i = 0; i < rowlist; i++)
                {
                    if (farmers_list.Items[i].ToString() == prename)
                    {
                        farmers_list.Items[i] = textname.Text;
                        farmers_list.Update();
                        break;
                    }
                }
                SetButton();
                LockUnLockMe(true);
            }



        }


        private void addcust_Click(object sender, EventArgs e)
        {
            if (addcust.Text == "&Add new Farmer")
            {

                LockUnLockMe(false);
                int newid;
                if (frmr_tb.RecordCount > 0)
                {

                    if (cpos != frmr_tb.RecordCount)
                    {
                        frmr_tb.MoveLast();
                        cpos = frmr_tb.RecordCount;
                    }
                    newid = frmr_tb.Fields["fID"].Value + 1;


                }
                else
                {
                    newid = 1;
                    //   textid.Text = (newid).ToString();
                    prev.Enabled = true;
                }
                emptyTxt();
                textid.Text = newid.ToString();
                addcust.Text = "&Save Details";
                fnd.Text = "&Cancel";
                prev.Enabled = false;
                nxt.Enabled = false;
                edt.Enabled = false;
                return;
            }



            if (addcust.Text == "&Save Details")
            {

                if (textname.Text == "")
                {
                    XtraMessageBox.Show("Invaild Name");
                    return;
                }

                frmr_tb.AddNew();

                GetData();
                frmr_tb.Update();
                SetButton();
                farmers_list.Items.Add(textname.Text);
                farmers_list.Update();
                cpos = frmr_tb.RecordCount;


            }

        }





        private void findRecord(int t, string s)
        {
            string field = "fNames";
            frmr_tb.MoveFirst();
            cpos = 1;
            if (s != "")
            {
                while (frmr_tb.EOF == false)
                {
                    if (t == 0)
                    {
                        field = "fID";
                    }

                    if (t == 1)
                    {
                        field = "fNames";
                    }


                    if (frmr_tb.Fields[field].Value.ToString().StartsWith(s))
                    {
                        this.FillText();
                        return;
                    }
                    frmr_tb.MoveNext();
                    cpos = cpos + 1;

                }
                XtraMessageBox.Show("Customer not Found");
            }


        }


        private void fnd_Click(object sender, EventArgs e)
        {
            if (fnd.Text == "&Find")
            {
                FINDform find = new FINDform();
                find.ShowDialog();

                findRecord(Program.FindType, Program.FindString);
                return;
            }
            else if (fnd.Text == "&Cancel")
            {
                SetButton();
                FillText();
                LockUnLockMe(true);
            }
        }

       

        private void FarmerFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TileNewFarmer.Enabled = true;
        }
    }
}