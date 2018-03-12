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
    public partial class CustomerFrm : DevExpress.XtraEditors.XtraForm
    {
        ADODB.Recordset cstmr_tb = new ADODB.Recordset();
        int cpos = 0;
        string prename;
        public CustomerFrm()
        {
            InitializeComponent();
        }



        private void emptyTxt()
        {
            textid.Text = "";
            textname.Text = "";
            textaddress.Text = "";
            textmobile.Text = "";
            textBox1.Text = "";
        }

        private void LockUnLockMe(bool stat)
        {
            textname.ReadOnly = stat;
            textaddress.ReadOnly = stat;
            textmobile.ReadOnly = stat;


        }
        private void FillText()
        {
            if (cstmr_tb.RecordCount > 0)
            {
                textid.Text = cstmr_tb.Fields["cID"].Value.ToString();
                textname.Text = cstmr_tb.Fields["CName"].Value.ToString();
                textaddress.Text = cstmr_tb.Fields["address"].Value.ToString();
                textmobile.Text = cstmr_tb.Fields["phn_num"].Value.ToString();
                textBox1.Text = cstmr_tb.Fields["obalance"].Value.ToString();
            }
        }
        private void GetData()
        {
            cstmr_tb.Fields["cID"].Value = int.Parse(textid.Text);
            cstmr_tb.Fields["CName"].Value = textname.Text;
            cstmr_tb.Fields["address"].Value = textaddress.Text;
            cstmr_tb.Fields["phn_num"].Value = textmobile.Text;
            cstmr_tb.Fields["obalance"].Value = float.Parse(textBox1.Text);
        }
        private void FillList()
        {
            if (cstmr_tb.RecordCount > 0)
            {
                while (cstmr_tb.EOF == false)
                {
                    customers_list.Items.Add(cstmr_tb.Fields["CName"].Value.ToString());
                    customers_list.Update();
                    cstmr_tb.MoveNext();
                }
                cstmr_tb.MoveFirst();
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
            addcust.Text = "&Add new Customer";


        }





        private void prev_Click(object sender, EventArgs e)
        {
            if (cpos > 1)
            {
                cstmr_tb.MovePrevious();
                this.FillText();
                cpos = cpos - 1;
            }

        }


        private void nxt_Click(object sender, EventArgs e)
        {

            if (cstmr_tb.RecordCount > cpos)
            {
                cstmr_tb.MoveNext();
                cpos = cpos + 1;
                this.FillText();


            }

        }

        private void edt_Click(object sender, EventArgs e)
        {
            if (edt.Text == "&Edit")
            {
                LockUnLockMe(false);
                textBox1.ReadOnly = true;
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
                cstmr_tb.Update();
                int rowlist = customers_list.Items.Count;
                for (int i = 0; i < rowlist; i++)
                {
                    if (customers_list.Items[i].ToString() == prename)
                    {
                        customers_list.Items[i] = textname.Text;
                        customers_list.Update();
                        break;
                    }
                }
                SetButton();
                LockUnLockMe(true);
            }



        }


        private void addcust_Click(object sender, EventArgs e)
        {
            if (addcust.Text == "&Add new Customer")
            {

                LockUnLockMe(false);
                textBox1.ReadOnly = false;
                int newid;
                if (cstmr_tb.RecordCount > 0)
                {

                    if (cpos != cstmr_tb.RecordCount)
                    {
                        cstmr_tb.MoveLast();
                        cpos = cstmr_tb.RecordCount;
                    }
                    newid = cstmr_tb.Fields["cID"].Value + 1;


                }
                else
                {
                    newid = 1;
                    //   textid.Text = (newid).ToString();
                    prev.Enabled = true;
                }
                emptyTxt();
                textid.Text = newid.ToString();
                addcust.Text = "&SAVE DETAILS";
                fnd.Text = "&Cancel";
                prev.Enabled = false;
                nxt.Enabled = false;
                edt.Enabled = false;
                return;
            }



            if (addcust.Text == "&SAVE DETAILS")
            {

                if (textname.Text == "")
                {
                    XtraMessageBox.Show("Invaild Name");
                    return;
                }

                cstmr_tb.AddNew();

                GetData();
                cstmr_tb.Update();
                SetButton();

                customers_list.Items.Add(textname.Text);
                customers_list.Update();
                cpos = cstmr_tb.RecordCount;
                LockUnLockMe(true);
                textBox1.ReadOnly = true;

            }

        }





        private void findRecord(int t, string s)
        {
            string field = "CName";
            cstmr_tb.MoveFirst();
            cpos = 1;

            int Flags = 0;
            if (s != "")
            {
                while (cstmr_tb.EOF == false&&Flags==0)
                {
                    if (t == 0)
                    {
                        field = "cID";
                    }

                    if (t == 1)
                    {
                        field = "CName";
                    }


                    if (cstmr_tb.Fields[field].Value.ToString().StartsWith(s))
                    {
                        this.FillText();
                        Flags = 1;
                        return;
                    }
                    cstmr_tb.MoveNext();
                    cpos = cpos + 1;

                }
                XtraMessageBox.Show("Customer not Found");
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void fnd_Click(object sender, EventArgs e)
        {
            if (fnd.Text == "&Find")
            {
               FINDform find = new FINDform();
                find.ShowDialog();
                if (Program.FindType != null && Program.FindString!= null)
                findRecord(Program.FindType, Program.FindString);
                return;
            }
            else if (fnd.Text == "&Cancel")
            {
                SetButton();
                FillText();
                LockUnLockMe(true);
                textBox1.ReadOnly = true;
            }
        }



        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            cstmr_tb.Open(@"select * from customerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

            textid.ReadOnly = true;
            LockUnLockMe(true);
            if (cstmr_tb.RecordCount > 0)
            {
                this.FillList();
                this.FillText();
                cpos = 1;
            }
            textBox1.ReadOnly = true;
        }

        private void CustomerFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TilaeNewCustomer.Enabled = true;
        }
    }
}