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
    public partial class commiditiesadd : DevExpress.XtraEditors.XtraForm
    {
        ADODB.Recordset comm_tb = new ADODB.Recordset();
        ADODB.Recordset temp_tb = new ADODB.Recordset();
        int cpos = 0;
        string prename;
        public commiditiesadd()
        {
            InitializeComponent();
        }

        private void commiditiesadd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TileNewCommodity.Enabled = true;
        }

        private void commiditiesadd_Load(object sender, EventArgs e)
        {
            comm_tb.Open(@"select * from commidities", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

            textid.ReadOnly = true;
            LockUnLockMe(true);
            if (comm_tb.RecordCount > 0)
            {
                this.FillList();
                this.FillText();
                cpos = 1;
            }
        }
      

        private void LockUnLockMe(bool stat)
        {
            textname.ReadOnly = stat;
            //   textaddress.ReadOnly = stat;
            textmobile.ReadOnly = stat;
            textid.ReadOnly = stat;

        }
        private void FillText()
        {
            if (comm_tb.RecordCount > 0)
            {
                textid.Text = comm_tb.Fields["coID"].Value.ToString();
                textname.Text = comm_tb.Fields["cname"].Value.ToString();
                //               textaddress.Text = comm_tb.Fields["price"].Value.ToString();
                textmobile.Text = comm_tb.Fields["weight"].Value.ToString();

            }
        }
        private void GetData()
        {
            comm_tb.Fields["coID"].Value = int.Parse(textid.Text);
            comm_tb.Fields["cname"].Value = textname.Text;
            //  comm_tb.Fields["price"].Value = int.Parse(textaddress.Text);
            comm_tb.Fields["weight"].Value = int.Parse(textmobile.Text);
        }
        private void FillList()
        {
            if (comm_tb.RecordCount > 0)
            {
                while (comm_tb.EOF == false)
                {
                    commidities_list.Items.Add(comm_tb.Fields["cname"].Value.ToString());
                    commidities_list.Update();
                    comm_tb.MoveNext();
                }
                comm_tb.MoveFirst();
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
            addcust.Text = "&Add new Commodity";


        }





        private void prev_Click_1(object sender, EventArgs e)
        {
            if (cpos > 1)
            {
                comm_tb.MovePrevious();
                this.FillText();
                cpos = cpos - 1;
            }

        }


        private void nxt_Click_1(object sender, EventArgs e)
        {

            if (comm_tb.RecordCount > cpos)
            {
                comm_tb.MoveNext();
                cpos = cpos + 1;
                this.FillText();


            }

        }

        private void edt_Click_1(object sender, EventArgs e)
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
                    textname.Focus();
                    textname.Select();
                    return;
                }
                if (textid.Text == "")
                {
                    XtraMessageBox.Show("Invaild ID");
                    textid.Focus();
                    textid.Select();
                    return;
                }
                if (textmobile.Text == "")
                {
                    XtraMessageBox.Show("Invaild Base Weight");
                    textmobile.Focus();
                    textmobile.Select();
                    return;
                }
                GetData();
                comm_tb.Update();
                int rowlist = commidities_list.Items.Count;
                for (int i = 0; i < rowlist; i++)
                {
                    if (commidities_list.Items[i].ToString() == prename)
                    {
                        commidities_list.Items[i] = textname.Text;
                        commidities_list.Update();
                        break;
                    }
                }
                SetButton();
                LockUnLockMe(true);
            }



        }
        private void emptyTxt()
        {
            textid.Text = "";
            textname.Text = "";
            //  textaddress.Text = "";
            textmobile.Text = "";

        }

        private void addcust_Click_1(object sender, EventArgs e)
        {
            if (addcust.Text == "&Add new Commodity")
            {

                LockUnLockMe(false);
                int newid;


                /*    if (comm_tb.RecordCount > 0)
                    {
                    
                        if (cpos != comm_tb.RecordCount)
                        {
                            comm_tb.MoveLast();
                            cpos = comm_tb.RecordCount;
                        }
                        newid = comm_tb.Fields["ID"].Value + 1;
                    

                    }
                    else
                    {
                        newid = 1;
                     //  textid.Text = (newid).ToString();
                        prev.Enabled = true;
                    }*/
                emptyTxt();
                // textid.Text = newid.ToString();
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
                /*  if (textaddress.Text == "")
                  {
                      XtraMessageBox.Show("Invaild price");
                      return;
                  }*/
                if (textmobile.Text == "")
                {
                    XtraMessageBox.Show("Invaild Weight");
                    return;
                }

                if (textid.Text == "")
                {
                    XtraMessageBox.Show("Invaild ID");
                    return;
                }
                else
                {
                    temp_tb.Open(@"select * from commidities where coID=" + Int32.Parse(textid.Text) + "", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    if (temp_tb.RecordCount != 0)
                    {
                        XtraMessageBox.Show("Same ID already exists");
                        temp_tb.Close();
                        return;
                    }
                    temp_tb.Close();
                }

                comm_tb.AddNew();

                GetData();
                comm_tb.Update();
                SetButton();
                commidities_list.Items.Add(textname.Text);
                commidities_list.Update();
                cpos = comm_tb.RecordCount;
                LockUnLockMe(true);

            }

        }





        private void findRecord(int t, string s)
        {
            string field = "Names";
            comm_tb.MoveFirst();
            cpos = 1;
            if (s != "")
            {
                while (comm_tb.EOF == false)
                {
                    if (t == 0)
                    {
                        field = "coID";
                    }

                    if (t == 1)
                    {
                        field = "cname";
                    }


                    if (comm_tb.Fields[field].Value.ToString().StartsWith(s))
                    {
                        this.FillText();
                        return;
                    }
                    comm_tb.MoveNext();
                    cpos = cpos + 1;

                }
                XtraMessageBox.Show("Commodity not Found");
            }


        }


        private void fnd_Click_1(object sender, EventArgs e)
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

        private void textmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}