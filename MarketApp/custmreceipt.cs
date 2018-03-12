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
    public partial class custmreceipt : DevExpress.XtraEditors.XtraForm
    {
        ADODB.Recordset Temp1 = new ADODB.Recordset();
        ADODB.Recordset Temp2 = new ADODB.Recordset();

        public custmreceipt()
        {
            InitializeComponent();
        }
        public void numvalidation(object sender, KeyPressEventArgs e)
        {


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }



        }
        private void custmreceipt_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
              textBox4.Text = "0";
            textBox3.Text = "0";
          // comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Properties.Items.Add("CASH");
            comboBox2.Properties.Items.Add("CHEQUE");
           // comboBox1.Properties.DropDownStyle = ComboBoxStyle.DropDownList;
            label7.Visible = false;
                 textBox5.Visible = false;

            Temp1.Open(@"select * from customerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            while (Temp1.EOF == false)
            {
                comboBox1.Properties.Items.Add(Temp1.Fields["CName"].Value);
                Temp1.MoveNext();
            }
            Temp1.Close();
            Temp1.Open(@"select * from payments", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            if (Temp1.RecordCount == 0)
                textBox1.Text = "1";
            else
            {
                Temp1.MoveLast();
                int a = Temp1.Fields["payID"].Value + 1;
                textBox1.Text = a.ToString();
                Temp1.MoveNext();
            }
            Temp1.Close();
        }



        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("SELECT A CUSTOMER");
                comboBox1.Select();
                comboBox1.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("SELECT PAY TYPE");
                comboBox2.Select();
                comboBox2.Focus();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("DISCOUNT CAN'T BE EMPTY");
                textBox4.Select();
                textBox4.Focus();
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("AMOUNT CAN'T BE EMPTY");
                textBox3.Select();
                textBox3.Focus();
                return;
            }
            if (comboBox2.Text == "CHEQUE" && textBox5.Text == "")
            {
                MessageBox.Show("ENTER CHEQUE NUMBER");
                textBox5.Select();
                textBox5.Focus();
                return;
            }
            Temp1.Open(@"select * from payments", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            Temp1.AddNew();
            Temp1.Fields["payID"].Value = Int64.Parse(textBox1.Text);
            Temp2.Open("SELECT * FROM customerdetails WHERE CName='" + comboBox1.Text + "'", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            Temp1.Fields["custID"].Value = Temp2.Fields["cID"].Value;

            if (comboBox2.Text == "CASH")
                Temp1.Fields["paytype"].Value = "CASH";
            else
                Temp1.Fields["paytype"].Value = "CHEQUE : " + textBox5.Text;
            Temp1.Fields["payday"].Value = dateTimePicker1.Value.ToShortDateString();
            Temp1.Fields["amount"].Value = Int64.Parse(textBox3.Text);
            Temp1.Fields["discount"].Value = Int64.Parse(textBox4.Text);
            Temp1.Fields["payamount"].Value = Int64.Parse(textBox4.Text) + Int64.Parse(textBox3.Text);
            Temp1.Update();
            Temp1.Close();
            Temp2.Fields["cbalance"].Value = Temp2.Fields["cbalance"].Value - (Int64.Parse(textBox4.Text) + Int64.Parse(textBox3.Text));
            Temp2.Update();
            Temp2.Close();
            MessageBox.Show("PAYMENT SUCCESSFUL");
            textBox4.Text = "0";
            textBox3.Text = "0";
            textBox2.Text = "0";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text = (Int64.Parse(textBox1.Text) + 1).ToString();

        }

        private void comboBox2_Validated(object sender, EventArgs e)
        {
            if (comboBox2.Text == "CHEQUE")
            {
                label7.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label7.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Temp1.Open("SELECT * FROM customerdetails WHERE CName='" + comboBox1.Text + "'", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                textBox2.Text = Temp1.Fields["cbalance"].Value.ToString();
                Temp1.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            textBox3.KeyPress += new KeyPressEventHandler(numvalidation);

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            textBox4.KeyPress += new KeyPressEventHandler(numvalidation);

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            { textBox4.Text = "0"; }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            { textBox3.Text = "0"; }
        }

        private void custmreceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TileCustomerpay.Enabled = true;

        }

    }
}