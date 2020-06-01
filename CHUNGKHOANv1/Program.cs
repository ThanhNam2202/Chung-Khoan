using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Data.SqlClient;
using System.Data;

namespace CHUNGKHOANv1
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand sqlcmd = new SqlCommand();
        public static String connstr;

        public static String mlogin = "sa";
        public static String password = "1";

        public static String database = "CHUNGKHOAN";

        // TODO : Declare Variable For Dependency part
        public static int changeCount = 0;
        public const string tableName = "BANGGIA";
        public const string statusMessage = "Đã có {0} thay đổi.";

        public static SqlConnection connection = null;
        public static SqlCommand command = null;
        public static DataSet dataToWatch = null;
        public static int vitriRow = 0;
        public static int vitriColumn = 0;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                //Program.connstr = "Data Source=ADMIN" + ";Initial Catalog=" +
                //      Program.database + ";User ID=" +
                //      Program.mlogin + ";password=" + Program.password;
                Program.connstr = "Data Source=ADMIN;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=1";
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


			BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new Form1());

        }
    }
}
