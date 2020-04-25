using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHUNGKHOAN
{
    public partial class ChungKhoan1 : Form
    {
        //private string sqlQuery = "SELECT ID, MACP FROM dbo.LENHDAT";
        private string sqlQuery = "SELECT ID, MACP, NGAYDAT, LOAIGD, LOAILENH,"
           +"SOLUONG, GIADAT, TRANGTHAILENH FROM dbo.LENHDAT";
        private DataSet dataToWatch = null;
        private const string tableName = "LENHDAT";
        public ChungKhoan1()
        {
            InitializeComponent();
        }

        private void ChungKhoan1_Load(object sender, EventArgs e)
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

        private void BatDau()
        {
            SqlDependency.Stop(Program.connstr);
            try
            {
                SqlDependency.Start(Program.connstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex);
                return;
            }
            if (Program.conn == null)
            {
                Program.conn = new SqlConnection(Program.connstr);
                Program.conn.Open();
            }
            if (Program.command == null)
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

            //DataTable dt = Program.ExecSqlDataTable(sqlQuery);

            using (SqlDataAdapter adapter = new SqlDataAdapter(Program.command))
            {
                adapter.Fill(dataToWatch, tableName);

                this.gridControl1.DataSource = dataToWatch;
                this.gridControl1.DataMember = tableName;
                this.gridControl1.MainView = GetBandedGridView();
                this.gridControl1.DataSource = GetDataTable();
            }
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

        private BandedGridView GetBandedGridView()
        {
            BandedGridView bandedView = new BandedGridView();
            // Set Customer Band
            SetGridBand(bandedView, "", new string[1] {""},
                     new string[1] { "Mã CP"});
            SetGridBand(bandedView, "DƯ MUA", new string[4] { "Giá 2", "KL 2", "Giá 1", "KL 1" },
                new string[4] { "giaM2", "kLM2", "giaM1", "kLM1" });
            SetGridBand(bandedView, "LỆNH KHỚP", new string[2] { "Giá Khớp", "KL Khớp",},
                new string[2] { "giaKhop", "kLKhop"});
            SetGridBand(bandedView, "DƯ BÁN", new string[4] { "Giá 1", "KL 1", "Giá 2", "KL 2"},
                new string[4] { "giaB1", "kLB1", "giaB2", "kLB2" });
            return bandedView;
        }

        private void SetGridBand(BandedGridView bandedView, string gridBandCaption, string[] capTions, 
            string[] columnNames)
        {
            var gridBand = new GridBand();
            gridBand.Caption = gridBandCaption;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            int nrOfColumns = columnNames.Length;
            BandedGridColumn[] bandedColumns = new BandedGridColumn[nrOfColumns];
            for (int i = 0; i < nrOfColumns; i++)
            {
                bandedColumns[i] = (BandedGridColumn)bandedView.Columns.AddField(columnNames[i]);
                bandedColumns[i].OwnerBand = gridBand;
                bandedColumns[i].Caption = capTions[i];
                bandedColumns[i].Visible = true;
            }
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Mã CP", typeof(Int32)),
                new DataColumn("giaM2", typeof(Int32)),
                new DataColumn("kLM2", typeof(Int32)),
                new DataColumn("giaM1", typeof(Int32)),
                new DataColumn("kLM1", typeof(Int32)),
                new DataColumn("giaKhop", typeof(Int32)),
                new DataColumn("kLKhop", typeof(Int32)),
                new DataColumn("giaB1", typeof(Int32)),
                new DataColumn("kLB1", typeof(Int32)),
                new DataColumn("giaB2", typeof(Int32)),
                new DataColumn("kLB2", typeof(Int32)) });
            dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            dt.Rows.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11);
            return dt;
        }
    }
}
