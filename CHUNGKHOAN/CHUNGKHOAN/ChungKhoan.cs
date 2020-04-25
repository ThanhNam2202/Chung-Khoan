using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHUNGKHOAN
{
    public partial class ChungKhoan : Form
    {
        private string sqlQuery = "SELECT ID, MACP FROM dbo.LENHDAT";
        private DataSet dataToWatch = null;
        private const string tableName = "LENHDAT";
        public ChungKhoan()
        {
            InitializeComponent();
        }
        private bool CheckPermission()
        {
            try
            {
                SqlClientPermission clientPermission = 
                    new SqlClientPermission(PermissionState.Unrestricted);
                clientPermission.Demand();
                return true;

            }
            catch
            {
                MessageBox.Show("Loi");
                return false;
            }
        }

        private void ChungKhoan_Load(object sender, EventArgs e)
        {
            if (CheckPermission())
            {
                BatDau();
            }
            else
            {
                MessageBox.Show("Bạn chưa kích hoạt dịch vụ Broker");
            }

        }
        private void BatDau()
        {
            SqlDependency.Stop(Program.connstr);
            try
            {
                SqlDependency.Start(Program.connstr);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi: " + ex);
                return;
            }
            if(Program.conn == null)
            {
                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
            }
            if(Program.command == null)
            {
                Program.command = new SqlCommand(sqlQuery, Program.conn);
            }
            if (dataToWatch == null)
                dataToWatch = new DataSet();
            LoadData();
        }

        private void LoadData()
        {
            dataToWatch.Clear();
            Program.command.Notification = null;
            SqlDependency dependency = new SqlDependency(Program.command);
            dependency.OnChange += dependency_OnChange;

            DataTable dt = Program.ExecSqlDataTable(sqlQuery);

            using (SqlDataAdapter adapter = new SqlDataAdapter(Program.command))
            {
                adapter.Fill(dataToWatch, tableName);

                this.gridControl1.DataSource = dataToWatch;
                this.gridControl1.DataMember = tableName;
            }

            gridControl1.DataSource = dt;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                OnChangeEventHandler tempDelegate = new OnChangeEventHandler(dependency_OnChange);

                object[] args = new[] { sender, e };

                i.BeginInvoke(tempDelegate, args);

                return;
            }
            SqlDependency dependency = (SqlDependency)sender;

            dependency.OnChange -= dependency_OnChange;

            MessageBox.Show(e.Info.ToString());

            LoadData();
        }
    }
}
