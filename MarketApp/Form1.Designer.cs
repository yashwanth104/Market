namespace MarketApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.NewEntryBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.PattiBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.BillsBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.PaymentsBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.ReportsBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.BackupBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.PassBtn = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.TileNewPatti = new DevExpress.XtraEditors.TileItem();
            this.TileNewFarmer = new DevExpress.XtraEditors.TileItem();
            this.TilaeNewCustomer = new DevExpress.XtraEditors.TileItem();
            this.TileNewCommodity = new DevExpress.XtraEditors.TileItem();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.TileFarmerpay = new DevExpress.XtraEditors.TileItem();
            this.TileCustomerpay = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane1.Buttons.Add(this.NewEntryBtn);
            this.tileNavPane1.Buttons.Add(this.PattiBtn);
            this.tileNavPane1.Buttons.Add(this.BillsBtn);
            this.tileNavPane1.Buttons.Add(this.PaymentsBtn);
            this.tileNavPane1.Buttons.Add(this.ReportsBtn);
            this.tileNavPane1.Buttons.Add(this.BackupBtn);
            this.tileNavPane1.Buttons.Add(this.PassBtn);
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane1.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            resources.ApplyResources(this.tileNavPane1, "tileNavPane1");
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // NewEntryBtn
            // 
            this.NewEntryBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.NewEntryBtn.Caption = "New Entry";
            this.NewEntryBtn.Name = "NewEntryBtn";
            this.NewEntryBtn.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.NewEntryBtn_ElementClick);
            // 
            // PattiBtn
            // 
            this.PattiBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.PattiBtn.Caption = "Patti";
            this.PattiBtn.Name = "PattiBtn";
            // 
            // BillsBtn
            // 
            this.BillsBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.BillsBtn.Caption = "Bills";
            this.BillsBtn.Name = "BillsBtn";
            // 
            // PaymentsBtn
            // 
            this.PaymentsBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.PaymentsBtn.Caption = "Payments";
            this.PaymentsBtn.Name = "PaymentsBtn";
            // 
            // ReportsBtn
            // 
            this.ReportsBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left;
            this.ReportsBtn.Caption = "Reports";
            this.ReportsBtn.Name = "ReportsBtn";
            // 
            // BackupBtn
            // 
            this.BackupBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.BackupBtn.Caption = "Backup";
            this.BackupBtn.Name = "BackupBtn";
            // 
            // PassBtn
            // 
            this.PassBtn.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.PassBtn.Caption = "Password";
            this.PassBtn.Name = "PassBtn";
            // 
            // navButton2
            // 
            this.navButton2.Caption = "Main Menu";
            this.navButton2.IsMain = true;
            this.navButton2.Name = "navButton2";
            // 
            // tileControl1
            // 
            this.tileControl1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Normal.Options.UseForeColor = true;
            this.tileControl1.AppearanceItem.Pressed.BackColor = ((System.Drawing.Color)(resources.GetObject("tileControl1.AppearanceItem.Pressed.BackColor")));
            this.tileControl1.AppearanceItem.Pressed.Options.UseBackColor = true;
            this.tileControl1.AppearanceText.Options.UseFont = true;
            this.tileControl1.BackgroundImage = global::MarketApp.Properties.Resources.grd1;
            resources.ApplyResources(this.tileControl1, "tileControl1");
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Groups.Add(this.tileGroup3);
            this.tileControl1.MaxId = 7;
            this.tileControl1.Name = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.TileNewPatti);
            this.tileGroup2.Items.Add(this.TileNewFarmer);
            this.tileGroup2.Items.Add(this.TilaeNewCustomer);
            this.tileGroup2.Items.Add(this.TileNewCommodity);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // TileNewPatti
            // 
            this.TileNewPatti.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("TileNewPatti.AppearanceItem.Normal.Font")));
            this.TileNewPatti.AppearanceItem.Normal.Options.UseFont = true;
            this.TileNewPatti.AppearanceItem.Normal.Options.UseForeColor = true;
            this.TileNewPatti.AppearanceItem.Pressed.BackColor = ((System.Drawing.Color)(resources.GetObject("TileNewPatti.AppearanceItem.Pressed.BackColor")));
            this.TileNewPatti.AppearanceItem.Pressed.Options.UseBackColor = true;
            tileItemElement1.Image = global::MarketApp.Properties.Resources.Patti;
            tileItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            resources.ApplyResources(tileItemElement1, "tileItemElement1");
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            this.TileNewPatti.Elements.Add(tileItemElement1);
            this.TileNewPatti.Id = 3;
            this.TileNewPatti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.TileNewPatti.Name = "TileNewPatti";
            this.TileNewPatti.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TileNewPatti_ItemClick);
            // 
            // TileNewFarmer
            // 
            this.TileNewFarmer.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("TileNewFarmer.AppearanceItem.Normal.Font")));
            this.TileNewFarmer.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement2.Image = global::MarketApp.Properties.Resources.FAme;
            tileItemElement2.ImageLocation = new System.Drawing.Point(-10, -10);
            resources.ApplyResources(tileItemElement2, "tileItemElement2");
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement2.TextLocation = new System.Drawing.Point(0, 6);
            this.TileNewFarmer.Elements.Add(tileItemElement2);
            this.TileNewFarmer.Id = 1;
            this.TileNewFarmer.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.TileNewFarmer.Name = "TileNewFarmer";
            this.TileNewFarmer.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TileNewFarmer_ItemClick);
            // 
            // TilaeNewCustomer
            // 
            this.TilaeNewCustomer.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("TilaeNewCustomer.AppearanceItem.Normal.Font")));
            this.TilaeNewCustomer.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement3.Image = global::MarketApp.Properties.Resources.cust;
            tileItemElement3.ImageLocation = new System.Drawing.Point(0, -10);
            tileItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside;
            resources.ApplyResources(tileItemElement3, "tileItemElement3");
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement3.TextLocation = new System.Drawing.Point(0, 5);
            this.TilaeNewCustomer.Elements.Add(tileItemElement3);
            this.TilaeNewCustomer.Id = 2;
            this.TilaeNewCustomer.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.TilaeNewCustomer.Name = "TilaeNewCustomer";
            this.TilaeNewCustomer.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TilaeNewCustomer_ItemClick);
            // 
            // TileNewCommodity
            // 
            this.TileNewCommodity.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("TileNewCommodity.AppearanceItem.Normal.Font")));
            this.TileNewCommodity.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement4.AnchorIndent = 0;
            tileItemElement4.Image = global::MarketApp.Properties.Resources.vegetables_variety;
            tileItemElement4.ImageLocation = new System.Drawing.Point(0, -20);
            tileItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            resources.ApplyResources(tileItemElement4, "tileItemElement4");
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.TileNewCommodity.Elements.Add(tileItemElement4);
            this.TileNewCommodity.Id = 4;
            this.TileNewCommodity.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.TileNewCommodity.Name = "TileNewCommodity";
            this.TileNewCommodity.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TileNewCommodity_ItemClick);
            // 
            // tileGroup3
            // 
            this.tileGroup3.Items.Add(this.TileFarmerpay);
            this.tileGroup3.Items.Add(this.TileCustomerpay);
            this.tileGroup3.Name = "tileGroup3";
            // 
            // TileFarmerpay
            // 
            resources.ApplyResources(tileItemElement5, "tileItemElement5");
            this.TileFarmerpay.Elements.Add(tileItemElement5);
            this.TileFarmerpay.Id = 5;
            this.TileFarmerpay.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.TileFarmerpay.Name = "TileFarmerpay";
            this.TileFarmerpay.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TileFarmerpay_ItemClick);
            // 
            // TileCustomerpay
            // 
            resources.ApplyResources(tileItemElement6, "tileItemElement6");
            this.TileCustomerpay.Elements.Add(tileItemElement6);
            this.TileCustomerpay.Id = 6;
            this.TileCustomerpay.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.TileCustomerpay.Name = "TileCustomerpay";
            this.TileCustomerpay.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.TileCustomerpay_ItemClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.tileNavPane1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    
        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton NewEntryBtn;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton PattiBtn;
        private DevExpress.XtraBars.Navigation.NavButton ReportsBtn;
        private DevExpress.XtraBars.Navigation.NavButton BillsBtn;
        private DevExpress.XtraBars.Navigation.NavButton PaymentsBtn;
        private DevExpress.XtraBars.Navigation.NavButton BackupBtn;
        private DevExpress.XtraBars.Navigation.NavButton PassBtn;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        public DevExpress.XtraEditors.TileItem TileNewPatti;
        public DevExpress.XtraEditors.TileItem TileNewFarmer;
        public DevExpress.XtraEditors.TileItem TilaeNewCustomer;
        public DevExpress.XtraEditors.TileItem TileNewCommodity;
        public DevExpress.XtraEditors.TileGroup tileGroup3;
        public DevExpress.XtraEditors.TileItem TileFarmerpay;
        public DevExpress.XtraEditors.TileItem TileCustomerpay;

    }
}

