namespace MarketApp
{
    partial class CustomerFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.textmobile = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.textaddress = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.textname = new DevExpress.XtraEditors.TextEdit();
            this.textid = new DevExpress.XtraEditors.TextEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.prev = new DevExpress.XtraEditors.SimpleButton();
            this.edt = new DevExpress.XtraEditors.SimpleButton();
            this.addcust = new DevExpress.XtraEditors.SimpleButton();
            this.fnd = new DevExpress.XtraEditors.SimpleButton();
            this.nxt = new DevExpress.XtraEditors.SimpleButton();
            this.customers_list = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textmobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textaddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customers_list)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.textmobile);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.textBox1);
            this.groupControl1.Controls.Add(this.textaddress);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.textname);
            this.groupControl1.Controls.Add(this.textid);
            this.groupControl1.Location = new System.Drawing.Point(173, 53);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(390, 268);
            this.groupControl1.TabIndex = 30;
            this.groupControl1.Text = "Customer Details";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(28, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mobile Number :";
            // 
            // textmobile
            // 
            this.textmobile.Location = new System.Drawing.Point(142, 164);
            this.textmobile.Name = "textmobile";
            this.textmobile.Size = new System.Drawing.Size(205, 20);
            this.textmobile.TabIndex = 3;
            this.textmobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.Location = new System.Drawing.Point(19, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Opening Balance :";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(68, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Address :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 205);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textaddress
            // 
            this.textaddress.Location = new System.Drawing.Point(142, 124);
            this.textaddress.Name = "textaddress";
            this.textaddress.Size = new System.Drawing.Size(205, 20);
            this.textaddress.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(18, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name  :";
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.Location = new System.Drawing.Point(39, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Customer ID  :";
            // 
            // textname
            // 
            this.textname.Location = new System.Drawing.Point(142, 83);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(205, 20);
            this.textname.TabIndex = 1;
            // 
            // textid
            // 
            this.textid.Location = new System.Drawing.Point(142, 41);
            this.textid.Name = "textid";
            this.textid.Size = new System.Drawing.Size(205, 20);
            this.textid.TabIndex = 0;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // prev
            // 
            this.prev.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.prev.Appearance.Options.UseFont = true;
            this.prev.Location = new System.Drawing.Point(191, 371);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(102, 51);
            this.prev.TabIndex = 2;
            this.prev.Text = "&Prev";
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // edt
            // 
            this.edt.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.edt.Appearance.Options.UseFont = true;
            this.edt.Location = new System.Drawing.Point(315, 371);
            this.edt.Name = "edt";
            this.edt.Size = new System.Drawing.Size(102, 51);
            this.edt.TabIndex = 1;
            this.edt.Text = "&Edit";
            this.edt.Click += new System.EventHandler(this.edt_Click);
            // 
            // addcust
            // 
            this.addcust.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.addcust.Appearance.Options.UseFont = true;
            this.addcust.Location = new System.Drawing.Point(241, 512);
            this.addcust.Name = "addcust";
            this.addcust.Size = new System.Drawing.Size(268, 51);
            this.addcust.TabIndex = 4;
            this.addcust.Text = "&Add new Customer";
            this.addcust.Click += new System.EventHandler(this.addcust_Click);
            // 
            // fnd
            // 
            this.fnd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.fnd.Appearance.Options.UseFont = true;
            this.fnd.Location = new System.Drawing.Point(293, 440);
            this.fnd.Name = "fnd";
            this.fnd.Size = new System.Drawing.Size(147, 51);
            this.fnd.TabIndex = 3;
            this.fnd.Text = "&Find";
            this.fnd.Click += new System.EventHandler(this.fnd_Click);
            // 
            // nxt
            // 
            this.nxt.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.nxt.Appearance.Options.UseFont = true;
            this.nxt.Location = new System.Drawing.Point(440, 371);
            this.nxt.Name = "nxt";
            this.nxt.Size = new System.Drawing.Size(102, 51);
            this.nxt.TabIndex = 0;
            this.nxt.Text = "&Next";
            this.nxt.Click += new System.EventHandler(this.nxt_Click);
            // 
            // customers_list
            // 
            this.customers_list.Location = new System.Drawing.Point(790, 53);
            this.customers_list.Name = "customers_list";
            this.customers_list.Size = new System.Drawing.Size(183, 453);
            this.customers_list.TabIndex = 36;
            // 
            // CustomerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 633);
            this.Controls.Add(this.customers_list);
            this.Controls.Add(this.nxt);
            this.Controls.Add(this.fnd);
            this.Controls.Add(this.addcust);
            this.Controls.Add(this.edt);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.groupControl1);
            this.Name = "CustomerFrm";
            this.Text = "Customer Details and Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerFrm_FormClosed);
            this.Load += new System.EventHandler(this.CustomerFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textmobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textaddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customers_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.TextEdit textname;
        private DevExpress.XtraEditors.TextEdit textid;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.TextEdit textmobile;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraEditors.TextEdit textaddress;
        private DevExpress.XtraEditors.SimpleButton prev;
        private DevExpress.XtraEditors.SimpleButton edt;
        private DevExpress.XtraEditors.SimpleButton addcust;
        private DevExpress.XtraEditors.SimpleButton fnd;
        private DevExpress.XtraEditors.SimpleButton nxt;
        private DevExpress.XtraEditors.ListBoxControl customers_list;
    }
}