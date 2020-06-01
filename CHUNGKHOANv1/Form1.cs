using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace CHUNGKHOANv1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        // private String sqlQuery = "SELECT MACP AS [MACP],  GIAMUA2 AS [GIA MUA 2], KHOILUONG_MUA2 AS [KLM2]," + 
        //     "GIAMUA1 AS [GIA MUA 1], KHOILUONG_MUA1 AS [KLM 1], GIAKHOP AS [GIÁ KHỚP], KL_KHOP AS [KL KHỚP]," + 
        //     "GIABAN1 AS [GIA BAN 1], KHOILUONG_BAN1 AS [KLB1], GIABAN2 AS [GIA BAN 2], KHOILUONG_BAN2 AS [KLB2] FROM dbo.BANGGIA";

        private String sqlQuery = "SELECT MACP AS [MACP],  GIAMUA2 AS [GIA MUA 2], KHOILUONG_MUA2 AS [KLM2], GIAMUA1 AS [GIA MUA 1], KHOILUONG_MUA1 AS [KLM 1], GIAKHOP AS [GIÁ KHỚP], KL_KHOP AS [KL KHỚP], GIABAN1 AS [GIA BAN 1], KHOILUONG_BAN1 AS [KLB1], GIABAN2 AS [GIA BAN 2], KHOILUONG_BAN2 AS [KLB2] FROM dbo.BANGGIA";
        public Form1()
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

        private void GetStarted()
        {
            Program.changeCount = 0;
            SqlDependency.Stop(Program.connstr);
            try
            {
                SqlDependency.Start(Program.connstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during initial connection", MessageBoxButtons.OK);
                return;
            }
            if (Program.connection == null)
            {
                Program.connection = new SqlConnection(Program.connstr);
                Program.connection.Open();
            }
            if (Program.command == null)

                Program.command = new SqlCommand(sqlQuery, Program.connection);

            if (Program.dataToWatch == null)
                Program.dataToWatch = new DataSet();
            GetData();
        }

        private void GetData()
        {
            Program.dataToWatch.Clear();
            Program.command.Notification = null;

            SqlDependency dependency = new SqlDependency(Program.command);
            dependency.OnChange += dependency_OnChange;

            using (SqlDataAdapter adapter = new SqlDataAdapter(Program.command))
            {
                adapter.Fill(Program.dataToWatch, Program.tableName);

                this.dataGridView.DataSource = Program.dataToWatch;
                this.dataGridView.DataMember = Program.tableName;
                try
                {
                    this.dataGridView.ClearSelection();
                    this.dataGridView.Rows[Program.vitriRow].Cells[Program.vitriColumn].Selected = true;
                }
                catch (Exception)
                {
                    this.dataGridView.ClearSelection();
                }

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
            GetData();
        }

        private void lENHKHOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lENHKHOPBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cHUNGKHOANDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Kết Nối Thất Bại!", "", MessageBoxButtons.OK);
                return;
            }

            if (CheckPermission())
            {
                GetStarted();
            }
            else
            {
                MessageBox.Show("Bạn chưa kích hoạt dịch vụ Brokaer");
            }

            cHUNGKHOANDataSet.EnforceConstraints = false;
            this.WindowState = FormWindowState.Normal;

            this.lENHDATTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHDAT);

            this.lENHKHOPTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHKHOP);

            //this.bANGGIATableAdapter.Fill(this.cHUNGKHOANDataSet.BANGGIA);

            DateTime dateTime = DateTime.Now;
            this.dateTimePicker.Text = dateTime.ToString();

            IDictionary<string, string> loaiGD = new Dictionary<string, string>();
            loaiGD.Add("M", "Mua");
            loaiGD.Add("B", "Bán");
            cmbLoaiGD.DataSource = new BindingSource(loaiGD, null);
            cmbLoaiGD.DisplayMember = "Value";
            cmbLoaiGD.ValueMember = "Key";

            IDictionary<string, string> loaiLenh = new Dictionary<string, string>();
            loaiLenh.Add("LO", "Khớp lệnh liên tục(LO)");
            //loaiLenh.Add("ATO", "Khớp lệnh định kỳ(ATO)");
            //loaiLenh.Add("ATC", "Khớp lệnh định kỳ(ATC )");
            cmbLoaiLenh.DataSource = new BindingSource(loaiLenh, null);
            cmbLoaiLenh.DisplayMember = "Value";
            cmbLoaiLenh.ValueMember = "Key";
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();

                if (this.txtMaCP.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập mã cổ phiếu!");
                    return;
                }
                if (this.txtSoLuong.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập số lượng!");
                    return;
                }
                if (this.txtGiaDat.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập giá đặt !");
                    return;
                }

                DateTime datetime = dateTimePicker.Value;
                String datetimeFormmat = datetime + "";
                String[] date = datetimeFormmat.Split(' ');
                String str = date[0];

                String[] tempsplit = str.Split('/');
                String joinstring = "-";
                String newdate = tempsplit[2] + joinstring + tempsplit[0] + joinstring + tempsplit[1];

                String strLenh = "SP_KHOPLENH_LO";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@macp", SqlDbType.NVarChar).Value = txtMaCP.Text;

                Program.sqlcmd.Parameters.Add("@Ngay", SqlDbType.NVarChar).Value = newdate;
                Program.sqlcmd.Parameters.Add("@LoaiGD", SqlDbType.Char).Value = cmbLoaiGD.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("@soluongMB", SqlDbType.Int).Value = txtSoLuong.Text;
                Program.sqlcmd.Parameters.Add("@giadatMB", SqlDbType.Float).Value = txtGiaDat.Text;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                MessageBox.Show("Đặt lệnh mua thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                this.lENHKHOPTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHKHOP);
                this.lENHDATTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHDAT);

                this.txtMaCP.Text = "";
                this.txtGiaDat.Text = "";
                this.txtSoLuong.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lệnh bán.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
