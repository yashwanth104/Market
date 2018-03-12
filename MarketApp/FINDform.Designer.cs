namespace MarketApp
{
    partial class FINDform
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.srchfield = new DevExpress.XtraEditors.TextEdit();
            this.srch = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srchfield.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(146, 24);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "NAME"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "ID:")});
            this.radioGroup1.Size = new System.Drawing.Size(160, 29);
            this.radioGroup1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SEARCH BY";
            // 
            // srchfield
            // 
            this.srchfield.Location = new System.Drawing.Point(146, 59);
            this.srchfield.Name = "srchfield";
            this.srchfield.Size = new System.Drawing.Size(139, 20);
            this.srchfield.TabIndex = 2;
            // 
            // srch
            // 
            this.srch.Location = new System.Drawing.Point(146, 85);
            this.srch.Name = "srch";
            this.srch.Size = new System.Drawing.Size(129, 23);
            this.srch.TabIndex = 3;
            this.srch.Text = "SEARCH";
            this.srch.Click += new System.EventHandler(this.srch_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // FINDform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 130);
            this.Controls.Add(this.srch);
            this.Controls.Add(this.srchfield);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioGroup1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(343, 169);
            this.MinimumSize = new System.Drawing.Size(343, 169);
            this.Name = "FINDform";
            this.Text = "FINDform";
            this.Load += new System.EventHandler(this.FINDform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srchfield.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.TextEdit srchfield;
        private DevExpress.XtraEditors.SimpleButton srch;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
      
    }
}