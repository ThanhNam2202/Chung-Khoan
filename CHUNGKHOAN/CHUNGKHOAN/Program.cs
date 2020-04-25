using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data;
using System.Data.SqlClient;

namespace CHUNGKHOAN
{
    static class Program
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlCommand command;
        public static string connstr = "Data Source=ADMIN;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=1";
        public static SqlDataAdapter adapter = new SqlDataAdapter();
        public static DataTable table = new DataTable();

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
                Program.conn.Close();
            try
            {
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                //MessageBox.Show("Ket noi thanh cong.\n ","", MessageBoxButtons.OK);
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        [STAThread]
        static void Main()
        {
            KetNoi();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new ChungKhoan1());
        }
    }
}
