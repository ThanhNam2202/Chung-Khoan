using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CHUNGKHOANv1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private String sqlQuery = "SELECT MACP AS [MÃ CP],  GIAMUA2 AS [GIÁ MUA 2]," +
            "KHOILUONG_MUA2 AS [KLM 2], GIAMUA1 AS [GIÁ MUA 1], KHOILUONG_MUA1 AS [KLM 1]," +
            "GIAKHOP AS [GIÁ KHỚP], KL_KHOP AS [KL KHỚP], GIABAN1 AS [GIÁ BÁN 1]," +
            "KHOILUONG_BAN1 AS [KLB 1], GIABAN2 AS [GIÁ BÁN 2]," +
            "KHOILUONG_BAN2 AS [KLB 2] FROM dbo.BANGGIA";

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void GetStart()
        {
            SqlDependency.Stop(Program.connstr);
            try
            {
                SqlDependency.Start(Program.connstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi Dependency!\n", MessageBoxButtons.OK);
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

            LoadData();
        }

        private void LoadData()
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

                for(int i = 0; i < 10; i++)
                {
                    this.dataGridView.Columns[i].Width = 63;
                }
                this.dataGridView.Columns[10].Width = 74;
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

            LoadData();
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
                return;
            }

            if (CheckPermission())
            {
                GetStart();
            }
            else
            {
                MessageBox.Show("Bạn chưa kích hoạt dịch vụ Broker!");
            }

            cHUNGKHOANDataSet.EnforceConstraints = false;

            this.lENHDATTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHDAT);

            this.lENHKHOPTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHKHOP);

            DateTime dateTime = DateTime.Now;
            this.dateTimePicker.Text = dateTime.ToString();

            IDictionary<string, string> loaiGD = new Dictionary<string, string>();
            loaiGD.Add("M", "Mua");
            loaiGD.Add("B", "Bán");
            cmbLoaiGD.DataSource = new BindingSource(loaiGD, null);
            cmbLoaiGD.DisplayMember = "Value";
            cmbLoaiGD.ValueMember = "Key";

            IDictionary<string, string> loaiLenh = new Dictionary<string, string>();
            loaiLenh.Add("LO", "Khớp lệnh liên tục - LO");
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
                    MessageBox.Show("Mã Cổ Phiếu Không Được Trống!");
                    return;
                }
                if (this.txtSoLuong.Text.Trim() == "")
                {
                    MessageBox.Show("   Số Lượng Không Được Trống!");
                    return;
                }
                if (this.txtGiaDat.Text.Trim() == "")
                {
                    MessageBox.Show("        Giá Không Được Trống!");
                    return;
                }

                if (MessageBox.Show("                        Xác nhận?", "        Thông Báo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }


                DateTime datetime = dateTimePicker.Value;
                String datetimeFormmat = datetime.ToString();
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
                //Program.conn.Close();

                MessageBox.Show("      Đặt lệnh thành công!", "        Thông Báo", MessageBoxButtons.OK);

                this.lENHKHOPTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHKHOP);
                this.lENHDATTableAdapter.Fill(this.cHUNGKHOANDataSet.LENHDAT);

                this.txtMaCP.Text = "";
                this.txtGiaDat.Text = "";
                this.txtSoLuong.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "        Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
