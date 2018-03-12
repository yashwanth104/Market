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
    public partial class FarmerPayment : DevExpress.XtraEditors.XtraForm
    {
        ADODB.Recordset Temp1 = new ADODB.Recordset();
        ADODB.Recordset Temp2 = new ADODB.Recordset();
        
        public FarmerPayment()
        {
            InitializeComponent();
        }

        private void FarmerPayment_Load(object sender, EventArgs e)
        {
            Temp1.Open(@"select * from farmerpayment", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            if (Temp1.RecordCount == 0)
                textBox1.Text = "1";
            else
                textBox1.Text = (Temp1.RecordCount + 1).ToString();

            Temp1.Close();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            Temp2.Open(@"select * from farmerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            while (Temp2.EOF == false)
            {

                Column1.Items.Add(Temp2.Fields["fNames"].Value.ToString());

                Temp2.MoveNext();
            }
            Temp2.Close();
           // comboBox2.Properties.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Properties.Items.Add("CASH");
            comboBox2.Properties.Items.Add("CHEQUE");
            label7.Visible = false;
            textBox5.Visible = false;
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGrid1_Edit);
         
        }
   
     public void numvalidation(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }



        }
        private void dataGrid1_Edit(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox t = e.Control as TextBox;
            if (t != null)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    t.KeyPress += new KeyPressEventHandler(numvalidation);
                }
            }
        }

        

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {// dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Items.Add("asd");
                string tempfname=dataGridView1.CurrentCell.EditedFormattedValue.ToString();
                DataGridViewComboBoxCell ComboBoxCell1 = new DataGridViewComboBoxCell();
                if (tempfname != "")
                {
                    Temp1.Open(@"select * from pattirefer WHERE fID IN (SELECT fID from farmerdetails WHERE fNames='" + tempfname + "')", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    while (Temp1.EOF == false)
                    {

                        ComboBoxCell1.Items.Add(Temp1.Fields["pattiId"].Value.ToString());
                        Temp1.MoveNext();
                    }
                    Temp1.Close();

                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1] = ComboBoxCell1;
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = "0";

                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                string temppatiId = dataGridView1.CurrentCell.EditedFormattedValue.ToString();
               
                  if (temppatiId != "")
                {
                    Temp1.Open(@"select * from pattirefer WHERE pattiID = "+Int32.Parse(temppatiId)+"", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = Temp1.Fields["payable"].Value;
                    Temp1.Close();

                    decimal a = 0;
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[2].EditedFormattedValue != null && dataGridView1.Rows[i].Cells[2].EditedFormattedValue != "")
                            a = a + decimal.Parse(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());

                    }
                    textBox2.Text = a.ToString();
                }
            
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                 string temppatiId = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].EditedFormattedValue.ToString();
               
                if (temppatiId != "")
                {
                    Temp1.Open(@"select * from pattirefer WHERE pattiID = " + Int32.Parse(temppatiId) + "", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    if (Temp1.Fields["payable"].Value!=null)
                    if (decimal.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString()) > Temp1.Fields["payable"].Value)
                    { MessageBox.Show("Amount is greater than Payable"); }
                    Temp1.Close();
                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("PAY Type can't be empty");
                comboBox2.Select();
                comboBox2.Focus();
                return;
            }
            if (comboBox2.Text == "CHEQUE")
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Cheque Details");
                    textBox5.Select();
                    textBox5.Focus();
                    return;
                }
            }
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j] == null || dataGridView1.Rows[i].Cells[j].Value == "")
                    {
                        MessageBox.Show("Field can't be empty");
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                        return;

                     }
                }
            }

            Temp1.Open(@"select * from farmerpayment", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                Temp1.AddNew();
                Temp1.Fields["fpayId"].Value = Int64.Parse(textBox1.Text);
                if(comboBox2.Text=="CASH")
                    Temp1.Fields["fpaytype"].Value = "CASH";
                else if(comboBox2.Text=="CHEQUE")
                    Temp1.Fields["fpaytype"].Value = "CHEQUE : "+textBox5.Text;

                Temp2.Open(@"select * from farmerdetails WHERE fNames='" + dataGridView1.Rows[i].Cells[0].EditedFormattedValue + "'", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                Temp1.Fields["fID"].Value = Temp2.Fields["fID"].Value;
                Temp2.Close();

                Temp1.Fields["pattiId"].Value = Int64.Parse(dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString());
                Temp1.Fields["Amount"].Value = decimal.Parse(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());

                Temp2.Open(@"select * from pattirefer WHERE pattiID = " + Int64.Parse(dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString()) + "", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                Temp2.Fields["payable"].Value = Temp2.Fields["payable"].Value - decimal.Parse(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());
                Temp2.Update();
                Temp2.Close();

                Temp1.Fields["PayDay"].Value = dateTimePicker1.Value.ToShortDateString();

                Temp1.Fields["TotalAmount"].Value = decimal.Parse(textBox2.Text);

                Temp1.Update();
            }
            Temp1.Close();
            MessageBox.Show("SAVED");
            textBox1.Text = (Int64.Parse(textBox1.Text) + 1).ToString();
            comboBox2.SelectedIndex = -1;
            label7.Visible = false;
            textBox5.Visible = false;
            textBox2.Text = "";
            dataGridView1.Rows.Clear();
                   
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            decimal a = 0;
            for (int i = 0; i < dataGridView1.RowCount-1;i++ )
            {
                if (dataGridView1.Rows[i].Cells[2].EditedFormattedValue != null && dataGridView1.Rows[i].Cells[2].EditedFormattedValue != "")
                a = a+decimal.Parse(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());

            }
            textBox2.Text = a.ToString();
        }

        private void FarmerPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TileFarmerpay.Enabled = true;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
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
    }
}

