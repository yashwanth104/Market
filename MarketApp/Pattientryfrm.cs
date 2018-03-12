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
    public partial class Pattientryfrm : DevExpress.XtraEditors.XtraForm
    {
        bool lb1 = true; int pattinum;
        ADODB.Recordset Temp1 = new ADODB.Recordset();
        ADODB.Recordset Temp2 = new ADODB.Recordset();
        ADODB.Recordset bill_entry = new ADODB.Recordset();
        ADODB.Recordset patti_entry = new ADODB.Recordset();
        ADODB.Recordset transact_entry = new ADODB.Recordset();
        AutoCompleteStringCollection idcollection, namecollection, comcollection, fidcollection, fnamecollection;
     
        public Pattientryfrm()
        {
            InitializeComponent();
        }
        bool cv = false, glflag = false;
        private void Pattientryfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.MainFrm.TileNewPatti.Enabled = true;
        }

        private void labelControl4_Click(object sender, EventArgs e)
        { }

        private void Pattientryfrm_Load(object sender, EventArgs e)
        {
            
          
            Temp1.Open(@"select * from pattirefer", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            {
                if (Temp1.RecordCount == 0)
                    pattilbl.Text = "1";
                else
                    while (Temp1.EOF == false)
                    {
                        int a = Temp1.Fields[0].Value + 1;
                        pattilbl.Text = a.ToString();
                        pattinum = a;
                        Temp1.MoveNext();
                    }
            }
            Temp1.Close();
            Temp1.Open(@"select * from customerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            idcollection = new AutoCompleteStringCollection();
            namecollection = new AutoCompleteStringCollection();
            comcollection = new AutoCompleteStringCollection();
            fidcollection = new AutoCompleteStringCollection();
            fnamecollection = new AutoCompleteStringCollection();
            while (Temp1.EOF == false)
            {
                //idcollection.Add(Temp1.Fields[0].Value.ToString());
                namecollection.Add(Temp1.Fields["CName"].Value);
                Temp1.MoveNext();
            }
            Temp1.Close();
            Temp2.Open(@"select * from commidities", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            while (Temp2.EOF == false)
            {
                idcollection.Add(Temp2.Fields["coID"].Value.ToString());
                comcollection.Add(Temp2.Fields["cname"].Value);
                Temp2.MoveNext();
            }
            Temp2.Close();
            Temp2.Open(@"select * from farmerdetails", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
            while (Temp2.EOF == false)
            {
                fidcollection.Add(Temp2.Fields[0].Value.ToString());
                fnamecollection.Add(Temp2.Fields[1].Value);
                Temp2.MoveNext();
            }
            Temp2.Close();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.ColumnCount = 7;
            //dataGridView1.AutoSize = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            // dataGridView1.AutoSize = true;
            // dataGridView1.Rows[].Height=10;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 350;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[5].Width = 115;
            dataGridView1.Columns[6].Width = 125;
            dataGridView1.Columns[0].Name = "C.ID";
            dataGridView1.Columns[1].Name = "Commodity";
            dataGridView1.Columns[2].Name = "Qty";
            dataGridView1.Columns[3].Name = "Customer";
            dataGridView1.Columns[4].Name = "Weight";
            dataGridView1.Columns[5].Name = "Rate";
            dataGridView1.Columns[6].Name = "Price";
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGrid1_Edit);
            textBox2.AutoCompleteCustomSource = fnamecollection;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = fidcollection;
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbgrosssale.ReadOnly = true;
            txtbexp.ReadOnly = true;
            txtbnetsale.ReadOnly = true;
            txtbhamali.ReadOnly = true;
            txtbcomm.ReadOnly = true;
            txtbbardan.ReadOnly = true; 
            txtbcomm.Text="0.00";
            txtbhamali.Text = "0.00";
            txtbfreight.Text = "0.00";
            txtbpacking.Text = "0.00";
            txtbgrosssale.Text = "0.00";
            txtbbardan.Text = "0.00";
            txtbexp.Text = "0.00";
            txtbnetsale.Text = "0.00";
            txtbother.Text = "0.00";

           

       


        }

           private void dataGrid1_Edit(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            TextBox t = e.Control as TextBox;
            t.KeyPress -= new KeyPressEventHandler(numvalidation);
           t.AutoCompleteCustomSource = null;

            if (t != null)
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 2 || dataGridView1.CurrentCell.ColumnIndex == 4 || dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    t.KeyPress += new KeyPressEventHandler(numvalidation);
                    //  t.KeyPress -= new KeyPressEventHandler(numvalidation);

                    return;
                }
                else
                {
                    t.KeyPress -= new KeyPressEventHandler(numvalidation);

                }
                t.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                t.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    t.AutoCompleteCustomSource = idcollection;
                    t.KeyPress += new KeyPressEventHandler(numvalidation);
                   
                    return;
                }
                else
                {
                    t.KeyPress -= new KeyPressEventHandler(numvalidation);
                    t.AutoCompleteCustomSource = null;
                }

                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                {         
                    t.AutoCompleteCustomSource = namecollection;
                    return;
                }
                else
                {
                    t.AutoCompleteCustomSource = null;
                }

                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    t.AutoCompleteCustomSource = comcollection;
                    return;
                }
                else
                {
                    t.AutoCompleteCustomSource = null;
                }
              

            }
        }
        public void numvalidation(object sender, KeyPressEventArgs e)
        {
            
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            
        
        
        }
        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        
        }

       

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                cv = true;
            else if (e.KeyCode == Keys.Escape)
            {
                glflag = true;
                cv = true;
            dataGridView1.ClearSelection();
                txtbfreight.Focus(); //dataGridView1.EndEdit();
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
           // if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
        //    if(dataGridView1.SelectedCells[e.ColumnIndex].ToString()=="") 
         //   XtraMessageBox.Show("field can't be empty");   

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if(!IsValueValid(e.FormattedValue))
            if (cv == true)
            {
                if (dataGridView1.CurrentCell.ColumnIndex != 0)
                    if (e.FormattedValue.ToString() == "")
                    {
                        e.Cancel = true;
                        MessageBox.Show("field can't be empty");
                        cv = false;
                        //  Temp1.Close();
                        if (glflag == true)
                        { glflag = false; }
                        return;
                    }
            }
            
           if (dataGridView1.CurrentCell.ColumnIndex == 0)
           {
               if (e.FormattedValue.ToString() != "")
               {
                   string query = "select * from commidities where coID=" + dataGridView1.CurrentCell.EditedFormattedValue + "";
                   Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                   if (Temp1.RecordCount != 0)
                   {
                       dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = Temp1.Fields[1].Value; 
                   }
                   else
                   {
                       MessageBox.Show("Enter saved commodity ID");
                       e.Cancel = true;
                   }
                   Temp1.Close();
               }
           }


                    if (dataGridView1.CurrentCell.ColumnIndex == 1)
           {
               if (e.FormattedValue.ToString() != "")
               {
                   string query = "select * from commidities where cname='" + dataGridView1.CurrentCell.EditedFormattedValue + "'";
                   Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                   if (Temp1.RecordCount != 0)
                   {
                       dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value = Temp1.Fields[0].Value;
                   }
                   else
                   {
                       MessageBox.Show("Enter saved commodity");
                       e.Cancel=true;
                   }
                   Temp1.Close();
               }
           }
                    if (dataGridView1.CurrentCell.ColumnIndex == 4)
                    {

                        if (e.FormattedValue.ToString() == "" || e.FormattedValue==null)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }

                    if (dataGridView1.CurrentCell.ColumnIndex == 5)
                    {

                        if (e.FormattedValue.ToString() != "" && lb1 == true)
                        {
                            string query = "select * from commidities where coID=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].EditedFormattedValue + "";
                            Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                               if (Temp1.RecordCount != 0)
                            {
                                 //  dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value = Temp1.Fields[2].Value * (decimal.Parse(dataGridView1.CurrentCell.EditedFormattedValue.ToString()) / Temp1.Fields[3].Value);
                                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value = (decimal.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].EditedFormattedValue.ToString())) *( decimal.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].EditedFormattedValue.ToString()) / Temp1.Fields["weight"].Value);
            
                               }
                            else
                            {
                                MessageBox.Show("Enter saved commodity ID");
                                e.Cancel = true;
                                lb1 = false;
                                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
                                Temp1.Close();
                                   return;
                            }
                            Temp1.Close();
                           if(dataGridView1.CurrentRow.Cells[3].ToString()=="")
                           {
                               MessageBox.Show("Enter saved customer");
                               
                               dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                             //  dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value ="";
                               
                               Temp1.Close();
                           return;
                           }
                            string query1 = "select * from customerdetails where CName='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].EditedFormattedValue + "'";
                            Temp1.Open(query1, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                            if (Temp1.RecordCount != 0)
                            {// dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value = Temp1.Fields[2].Value * (float.Parse(dataGridView1.CurrentCell.EditedFormattedValue.ToString()) / Temp1.Fields[3].Value); }
                            }
                            else
                            {
                                MessageBox.Show("Enter saved customer");
                              //  dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value = "";
                               
                                e.Cancel = true;
                                lb1 = false;
                                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                            }
                            Temp1.Close();
                           
                        }
                        else { lb1 = true; }

           
                    }
                    if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    {
                        string query1 = "select * from customerdetails where CName='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].EditedFormattedValue + "'";
                        Temp1.Open(query1, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                        if (Temp1.RecordCount == 0)
                        {
                            MessageBox.Show("Enter saved customer");
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value = "";
                            e.Cancel = true;
                            }
                        Temp1.Close();
                           
                        
                    }
                  /*  if (dataGridView1.CurrentCell.ColumnIndex == 2)
                    {string ss1;
                     ss1 =  dataGridView1.CurrentCell.Value.ToString();
                    if(ss1)
                    }*/
                   
       }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (dataGridView1.RowCount > 1)
                {
                    patti_entry.Open(@"select * from pattirefer", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                    patti_entry.AddNew();
                    patti_entry.Fields["pattiId"].Value = pattilbl.Text;
                    patti_entry.Fields["fID"].Value = int.Parse(textBox1.Text);
                    patti_entry.Fields["comm"].Value = float.Parse(txtbcomm.Text);
                    patti_entry.Fields["bardan"].Value = float.Parse(txtbbardan.Text);
                    patti_entry.Fields["hamali"].Value = float.Parse(txtbhamali.Text);
                    patti_entry.Fields["freight"].Value = float.Parse(txtbfreight.Text);
                    patti_entry.Fields["packing"].Value = float.Parse(txtbpacking.Text);
                    patti_entry.Fields["other"].Value = float.Parse(txtbother.Text);
                    patti_entry.Fields["netsale"].Value = float.Parse(txtbnetsale.Text);

                    patti_entry.Fields["exp"].Value = float.Parse(txtbexp.Text);
                    patti_entry.Fields["grosssale"].Value = float.Parse(txtbgrosssale.Text);
                    patti_entry.Fields["patti_date"].Value = dateTimePicker1.Value.ToShortDateString();

                    transact_entry.Open(@"select * from transactions", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);

                    int  rc = dataGridView1.RowCount - 1;
                    for (int i = 0; i < rc; i++)
                    {
                        transact_entry.AddNew();
                        transact_entry.Fields["tID"].Value = transact_entry.RecordCount + 1;
                        transact_entry.Fields["pattiID"].Value = pattilbl.Text;
                        
                            transact_entry.Fields["coID"].Value = dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString();
                            transact_entry.Fields["coweight"].Value = dataGridView1.Rows[i].Cells[4].EditedFormattedValue.ToString();
                            transact_entry.Fields["coprice"].Value = dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString();
                            transact_entry.Fields["rate"].Value = dataGridView1.Rows[i].Cells[5].EditedFormattedValue.ToString();
                            transact_entry.Fields["qty"].Value = dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString();
                            string query1 = "select * from customerdetails where CName='" + dataGridView1.Rows[i].Cells[3].EditedFormattedValue + "'";
                            Temp1.Open(query1, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                            transact_entry.Fields["cID"].Value = Temp1.Fields["cID"].Value;




                            string query2 = "select * from billrefer where cID = " + Temp1.Fields["cID"].Value + " AND bill_date = #" + dateTimePicker1.Value.ToShortDateString() + "#";

                            bill_entry.Open(query2, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                            if (bill_entry.RecordCount == 0)
                            {
                                bill_entry.AddNew();
                                Temp2.Open(@"select * from billrefer", Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                                if (Temp2.RecordCount == 0)
                                {
                                    bill_entry.Fields["billID"].Value = 1;
                                    transact_entry.Fields["billId"].Value = 1;
                                }
                                else 
                                {
                                    bill_entry.Fields["billID"].Value = Temp2.RecordCount + 1;
                                    transact_entry.Fields["billId"].Value = Temp2.RecordCount + 1;
                                }
                                Temp2.Close();
                                bill_entry.Fields["saleamt"].Value = dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString();
                                bill_entry.Fields["totalamt"].Value = dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString();
                                bill_entry.Fields["cID"].Value = Temp1.Fields["cID"].Value;
                                bill_entry.Fields["bill_date"].Value = dateTimePicker1.Value.ToShortDateString();
                               
                                decimal oldbalance=decimal.Parse(Temp1.Fields["cbalance"].Value.ToString());
                                Temp1.Fields["cbalance"].Value = decimal.Parse(dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString())+oldbalance;
                                Temp1.Update();
                            }
                            else
                            {
                                transact_entry.Fields["billId"].Value = bill_entry.Fields["billID"].Value;
                                decimal tempsaleamnt;
                                tempsaleamnt = bill_entry.Fields["saleamt"].Value + decimal.Parse(dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString());
                                bill_entry.Fields["saleamt"].Value = decimal.Parse(tempsaleamnt.ToString());
                                bill_entry.Fields["totalamt"].Value = decimal.Parse(tempsaleamnt.ToString());
                              
                                decimal oldbalance = decimal.Parse(Temp1.Fields["cbalance"].Value);
                                Temp1.Fields["cbalance"].Value = decimal.Parse(dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString()) + oldbalance;
                                Temp1.Update();
                            }
                            Temp1.Close();
                            bill_entry.Update();
                            bill_entry.Close();
                           
                    }
                    transact_entry.Update();
                    transact_entry.Close();
                    patti_entry.Update();
                    patti_entry.Close();
                    dataGridView1.Rows.Clear();
                    pattinum += 1;
                    pattilbl.Text = pattinum.ToString();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtbbardan.ResetText();//Clear();
                    txtbcomm.ResetText();
                    txtbexp.ResetText();
                    txtbfreight.ResetText();
                    txtbgrosssale.ResetText();
                    txtbhamali.ResetText();
                    txtbnetsale.ResetText();
                    txtbother.ResetText();
                    txtbpacking.ResetText();
                    Program.DB.Close();
                    Program.DB.Open();
                    
      /*       pattireportprint PP = new pattireportprint();
                    PP.PrintDialog();
                  PP.BeginUpdate();
                    int b=pattinum-1;
                    PP.FilterString = "[npattiid] = "+ b +"";
                    PP.EndUpdate();

                    using (ReportPrintTool printTool = new ReportPrintTool(PP))
                    {

                        printTool. showPreviewDialog(UserLookAndFeel.Default);

                    }*/

          
                }
                else 
                {
                    MessageBox.Show("can't generate patti on empty list");
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                }
            }
            else 
            {
                MessageBox.Show("Enter farmer Id");
                textBox1.Focus();
                return;
            }

        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            while (cv == true)
            {
                cv = false;
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].FormattedValue.ToString() == "")
                {
                    if (glflag == true)
                    { glflag = false; }
                    e.Cancel = true;
                    MessageBox.Show("Enter commodity ID");
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
                    return;
                }
                else if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].FormattedValue.ToString() == "")
                {
                    if (glflag == true)
                    { glflag = false; }
                    e.Cancel = true;
                    MessageBox.Show("Enter quantity");
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2];
                    return;
                }
                else if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].FormattedValue.ToString() == "")
                {
                    if (glflag == true)
                    { glflag = false; }
                    e.Cancel = true;
                    MessageBox.Show("Enter customer");
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                    return;
                }
                else if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].FormattedValue.ToString() == "")
                {
                    if (glflag == true)
                    { glflag = false; }
                    e.Cancel = true;
                    MessageBox.Show("Enter weight");
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4];
                    return;
                }
                else if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].FormattedValue.ToString() == "")
                {
                    if (glflag == true)
                    { glflag = false; }
                    e.Cancel = true;
                    MessageBox.Show("Enter Rate");
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5];
                    return;
                }
                string query = "select * from commidities where coID=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].EditedFormattedValue + "";
                Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                if (Temp1.RecordCount != 0)
                {
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].EditedFormattedValue.ToString()) * (Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].EditedFormattedValue.ToString()) / Temp1.Fields["weight"].Value);
                }
                else
                {
                    MessageBox.Show("Enter saved commodity ID");
                    e.Cancel = true;

                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];
                    Temp1.Close();
                    return;
                }
                Temp1.Close();
                string query1 = "select * from customerdetails where CName='" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].EditedFormattedValue + "'";
                Temp1.Open(query1, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                if (Temp1.RecordCount == 0)
                {
                    if (glflag == true)
                    { glflag = false; }
                    MessageBox.Show("Enter saved customer");
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value = "";
                    e.Cancel = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3];
                    Temp1.Close();
                    return;
                }

                Temp1.Close();


            }
          
        }
     

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
          //  textBox1.Text
           // Temp1.Close();
           if (textBox1.Text != "")
            {
                string query = "select * from farmerdetails where fID=" + Int32.Parse(textBox1.Text) + "";
                Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                if (Temp1.RecordCount != 0)
                {
                    textBox2.Text = Temp1.Fields[1].Value;
                }
                else
                {
                    MessageBox.Show("Enter saved farmer ID");
                    e.Cancel = true;
                }
                Temp1.Close();
            }
        
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != "")
            {
                string query = "select * from farmerdetails where fNames='" + textBox2.Text + "'";
                Temp1.Open(query, Program.DB, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic);
                if (Temp1.RecordCount != 0)
                {
                    int a;
                    a= Temp1.Fields[0].Value;
                    textBox1.Text = a.ToString();
                }
                else
                {
                    MessageBox.Show("Enter saved farmer names");
                    e.Cancel = true;
                }
                Temp1.Close();
            }
            else
            { MessageBox.Show("select farmer");
            e.Cancel = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataGridView1_Validating(object sender, CancelEventArgs e)
        {
            if(glflag==true)
            {
                int a, cflag = 0,tqty=0;
                float grosssale = 0,bardan=0,commision=0,exp=0,netsale=0,hamali=0,zro=0;
                a = dataGridView1.RowCount-1;
                for(int i=0;i<a;i++)
                {
                    for (int j = 0; j <= 6; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j] == null)
                        {

                            e.Cancel = true;
                            cflag = 1;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                            MessageBox.Show("field can't be empty");
                        }
                    }
                    grosssale += float.Parse(dataGridView1.Rows[i].Cells[6].EditedFormattedValue.ToString());
                    tqty += int.Parse(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());
                }
                if (cflag == 0)
                {
                   txtbgrosssale.Text = grosssale.ToString();
                    hamali=2*tqty;
                   txtbhamali.Text = hamali.ToString();
                   bardan = (4 * grosssale)/100;
                   commision = bardan;
                    txtbbardan.Text = bardan.ToString();
                    txtbcomm.Text = commision.ToString();
                    exp = bardan + commision + hamali;
                    txtbexp.Text = exp.ToString();
                    netsale = grosssale - exp;
                    txtbnetsale.Text = netsale.ToString();
                    txtbother.Text = zro.ToString();
                    txtbfreight.Text = zro.ToString();
                    txtbpacking.Text = zro.ToString();
                }
                glflag = false;
          }
         }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.KeyPress += new KeyPressEventHandler(numvalidation);
        }

        private void txtbfreight_KeyDown(object sender, KeyEventArgs e)
        {
            txtbfreight.KeyPress += new KeyPressEventHandler(numvalidation);
        }

        private void txtbpacking_KeyDown(object sender, KeyEventArgs e)
        {
            txtbpacking.KeyPress += new KeyPressEventHandler(numvalidation);
        }

        private void txtbother_KeyDown(object sender, KeyEventArgs e)
        {
            txtbother.KeyPress += new KeyPressEventHandler(numvalidation);
        }

        private void txtbfreight_Leave(object sender, EventArgs e)
        {
            float expe, commi, hamali, freight, pack, other, grossale, bardan, netsale;
          //  expe = float.Parse(txtbexp.Text);
            commi = float.Parse(txtbcomm.Text);
            hamali = float.Parse(txtbhamali.Text);
            freight = float.Parse(txtbfreight.Text);
            pack = float.Parse(txtbpacking.Text);
            other = float.Parse(txtbother.Text);
            grossale = float.Parse(txtbgrosssale.Text);
            bardan = float.Parse(txtbbardan.Text);

            expe = commi + hamali + freight + pack + other + bardan;
            netsale = grossale - expe;
            txtbexp.Text = expe.ToString();
            txtbnetsale.Text = netsale.ToString();
        }

        private void txtbpacking_Leave(object sender, EventArgs e)
        {
            float expe, commi, hamali, freight, pack, other, grossale, bardan, netsale;
            //  expe = float.Parse(txtbexp.Text);
            commi = float.Parse(txtbcomm.Text);
            hamali = float.Parse(txtbhamali.Text);
            freight = float.Parse(txtbfreight.Text);
            pack = float.Parse(txtbpacking.Text);
            other = float.Parse(txtbother.Text);
            grossale = float.Parse(txtbgrosssale.Text);
            bardan = float.Parse(txtbbardan.Text);

            expe = commi + hamali + freight + pack + other + bardan;
            netsale = grossale - expe;
            txtbexp.Text = expe.ToString();
            txtbnetsale.Text = netsale.ToString();
        }

        private void txtbother_Leave(object sender, EventArgs e)
        {
            float expe, commi, hamali, freight, pack, other, grossale, bardan, netsale;
            //  expe = float.Parse(txtbexp.Text);
            commi = float.Parse(txtbcomm.Text);
            hamali = float.Parse(txtbhamali.Text);
            freight = float.Parse(txtbfreight.Text);
            pack = float.Parse(txtbpacking.Text);
            other = float.Parse(txtbother.Text);
            grossale = float.Parse(txtbgrosssale.Text);
            bardan = float.Parse(txtbbardan.Text);

            expe = commi + hamali + freight + pack + other + bardan;
            netsale = grossale - expe;
            txtbexp.Text = expe.ToString();
            txtbnetsale.Text = netsale.ToString();
        }

       

    }
}
