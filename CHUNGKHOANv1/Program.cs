using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;
using System.Data;

namespace CHUNGKHOANv1
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand sqlcmd = new SqlCommand();
        public static String connstr;
        public const string tableName = "BANGGIA";
        public static SqlConnection connection = null;
        public static SqlCommand command = null;
        public static DataSet dataToWatch = null;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();

            try
            {
                Program.connstr = "Data Source=ADMIN;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=1";
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!\n " + e.Message, "", MessageBoxButtons.OK);
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
