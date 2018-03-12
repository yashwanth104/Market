using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Data.OleDb;

namespace MarketApp
{
    static class Program
    {
        public static ADODB.Connection DB = new ADODB.Connection();
        public static int FindType; 
        public static string FindString;
        public static Form1 MainFrm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = C:\Users\Yashwanth\Desktop\firstdb.accdb";
            DB.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            MainFrm = new Form1();
            Application.Run(MainFrm);
        }
    }
}
