using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuAn
{
    public partial class MainForm : Form
    {
        private DataTable dt;
        private int branchId = WorkingContext.Instance.CurrentBranchId;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            tsslLoginName.Text += WorkingContext.Instance.CurrentLoginName;
            tsslBranch.Text += WorkingContext.Instance.CurrentBranch;
            tsslGroup.Text += WorkingContext.Instance.CurrentLoginInfo.RoleName;
            cbbChiNhanh.Text = WorkingContext.Instance.CurrentBranch;
            #region node
            /*DisplayNhanVien();
            DuAn(WorkingContext.Instance.CurrentBranchId);
            cbbDuan.Text = cbbDuan.Items[0].ToString();
            DisplayChucVu();
            DisplayDuAn();
            DisplayPhanCong();
            NhanVien(WorkingContext.Instance.CurrentBranchId);
           DisplayNhanVienThamgianhieuduannhat(); */
            #endregion


        }
        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayNhanVien();
            DuAn();
            cbbDuan.Text = cbbDuan.Items[0].ToString();
            DisplayChucVu();
            DisplayDuAn();
            DisplayPhanCong();
            NhanVien(WorkingContext.Instance.CurrentBranchId);
            DisplayNhanVienThamgianhieuduannhat();
        }


        private void connect(int branchId, string SqlString, DataGridView dgv)
        {
             dt = new DataTable();
            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            sda.Fill(dt);
            dgv.DataSource = dt;
            connection.Close();
        }
        private void connect(string SqlString, DataGridView dgv)
        {
            dt = new DataTable();
            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            sda.Fill(dt);
            dgv.DataSource = dt;
            connection.Close();
        }
        #region NhanVien
        private void DisplayNhanVien()
        {
            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "select * from LINK0.QuanLyDuAn.dbo.NhanVien";
                connect(query, dgvNhanVien);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "Select * from NhanVien";
                connect(branchId, query, dgvNhanVien);
            }
            else
            {
                query = "select * from LINK.QuanLyDuAn.dbo.NhanVien";
                connect(query, dgvNhanVien);
            }
          
        }
        private void FormNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbChiNhanh.SelectedIndex;
            cbbChiNhanh.SelectedIndex = -1;
            cbbChiNhanh.SelectedIndex = index;
        }
        private void tsmThemNV_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.FormClosed += FormNhanVien_FormClosed;
            formNhanVien.Show(this);

        }

        private void tsmCapnhapNV_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNhanVien.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FormNhanVien formNhanVien = new FormNhanVien();
                formNhanVien.FormClosed += new FormClosedEventHandler(FormNhanVien_FormClosed);

                formNhanVien.Show(this);
               formNhanVien.DisplayNhanVienInfo(rowView);
            }
        }

        private void tsmXoaNV_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ChucVu
        private void DisplayChucVu()
        {
            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "select * from LINK0.QuanLyDuAn.dbo.ChucVu";
                connect(query, dgvChucVu);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "Select * from ChucVu";
                connect(branchId, query, dgvChucVu);
            }
            else
            {
                query = "select * from LINK.QuanLyDuAn.dbo.ChucVu";
                connect(query, dgvChucVu);
            }
        }
        private void tsmThemchucvu_Click(object sender, EventArgs e)
        {
            FormChucVu formChucVu = new FormChucVu();
            formChucVu.FormClosed += FormNhanVien_FormClosed;
            formChucVu.Show(this);
        }
        #region note
        private void tsmSuachucvu_Click(object sender, EventArgs e)
        {
            /*if (dgvChucVu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvChucVu.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FormChucVu formChucVu = new FormChucVu();
                formChucVu.FormClosed += new FormClosedEventHandler(FormNhanVien_FormClosed);

                formChucVu.Show(this);
                formChucVu.DisplayFoodInfo(rowView);
            }*/
        }
        #endregion

        #endregion


        #region DuAn
        private void DisplayDuAn()
        {
            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "select * from LINK0.QuanLyDuAn.dbo.DuAn";
                connect(query, dgvDuan);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "Select * from DuAn";
                connect(branchId, query, dgvDuan);
            }
            else
            {
                query = "select * from LINK.QuanLyDuAn.dbo.DuAn";
                connect(query, dgvDuan);
            }
        }
        #endregion

        #region Phancong
        private void DisplayPhanCong()
        {
            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "select * from LINK0.QuanLyDuAn.dbo.PhanCong";
                connect(query, dgvPhancong);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "Select * from PhanCong";
                connect(branchId, query, dgvPhancong);
            }
            else
            {
                query = "select * from LINK.QuanLyDuAn.dbo.PhanCong";
                connect(query, dgvPhancong);
            }
        }
        #endregion

        #region ThongKe

        private void connect(string SqlString, ComboBox cbb)
        {
            dt = new DataTable();
            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            sda.Fill(dt);
            connection.Close();
            connection.Dispose();
            cbb.DataSource = dt;
            cbbDuan.DisplayMember = "TenDA";
            cbbDuan.ValueMember = "MaDA";
            connection.Close();
        }

        private void connect(int branchId, string SqlString, ComboBox cbb)
        {
            dt = new DataTable();
            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, connection);
            sda.Fill(dt);
            connection.Close();
            connection.Dispose();
            cbb.DataSource = dt;
            cbbDuan.DisplayMember = "TenDA";
            cbbDuan.ValueMember = "MaDA";
           
        }
        private void DuAn()
        {
            #region note
            /* var connectionName = string.Format("CN0{0}", CN);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("SELECT * FROM DuAn", connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            connection.Open();
            sda.Fill(dt);
            connection.Close();
            connection.Dispose();
            cbbDuan.DataSource = dt;
            cbbDuan.DisplayMember = "TenDA";
            cbbDuan.ValueMember = "MaDA";
           */
            #endregion

            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "select * from LINK0.QuanLyDuAn.dbo.DuAn";
                connect(query, cbbDuan);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "Select * from DuAn";
                connect(branchId, query, cbbDuan);
            }
            else
            {
                query = "select * from LINK.QuanLyDuAn.dbo.DuAn";
                connect(query, cbbDuan);
            }

        }

        private void cbbDuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDuan.SelectedIndex == -1) return;

        
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec LINK0.QuanLyDuAn.dbo.sp_DS_NVthamgiamotduanpt @MaDA", connection);
                command.Parameters.Add("@MaDA", SqlDbType.VarChar);
                if (cbbDuan.SelectedValue is DataRowView)
                {
                    DataRowView rowView = cbbDuan.SelectedValue as DataRowView;
                    command.Parameters["@MaDA"].Value = rowView["MaDA"];
                }
                else
                {
                    command.Parameters["@MaDA"].Value = cbbDuan.SelectedValue;
                }


                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvChonDA.DataSource = dt;
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec sp_DS_NVthamgiamotduanpt @MaDA", connection);
                command.Parameters.Add("@MaDA", SqlDbType.VarChar);
                if (cbbDuan.SelectedValue is DataRowView)
                {
                    DataRowView rowView = cbbDuan.SelectedValue as DataRowView;
                    command.Parameters["@MaDA"].Value = rowView["MaDA"];
                }
                else
                {
                    command.Parameters["@MaDA"].Value = cbbDuan.SelectedValue;
                }


                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvChonDA.DataSource = dt;
            }
            else
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec LINK.QuanLyDuAn.dbo.sp_DS_NVthamgiamotduanpt @MaDA", connection);
                command.Parameters.Add("@MaDA", SqlDbType.VarChar);
                if (cbbDuan.SelectedValue is DataRowView)
                {
                    DataRowView rowView = cbbDuan.SelectedValue as DataRowView;
                    command.Parameters["@MaDA"].Value = rowView["MaDA"];
                }
                else
                {
                    command.Parameters["@MaDA"].Value = cbbDuan.SelectedValue;
                }


                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvChonDA.DataSource = dt;
            }

            #region note
            /* var connectionName = string.Format("CN0{0}", branchId);
             var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
             connectionString = string.Format(connectionString, "sa", "1812816");
             var connection = new SqlConnection();
             connection.ConnectionString = connectionString;
             var command = new SqlCommand("exec sp_DS_NVthamgiamotduan @MaDA", connection);
             command.Parameters.Add("@MaDA", SqlDbType.VarChar);
             if (cbbDuan.SelectedValue is DataRowView)
             {
                 DataRowView rowView = cbbDuan.SelectedValue as DataRowView;
                 command.Parameters["@MaDA"].Value = rowView["MaDA"];
             }
             else
             {
                 command.Parameters["@MaDA"].Value = cbbDuan.SelectedValue;
             }


             SqlDataAdapter sda = new SqlDataAdapter(command);
             dt = new DataTable();
             connection.Open();
             sda.Fill(dt);
             connection.Close();
             connection.Dispose();
             dgvChonDA.DataSource = dt;*/
            #endregion


        }

        private void btnThongkeTL_Click(object sender, EventArgs e)
        {
            if (cbbThang.SelectedIndex == -1 || cbbNam.SelectedIndex == -1) return;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec LINK0.QuanLyDuAn.dbo.sp_TienluongNVtheothangpt @Month, @Year", connection);
                command.Parameters.Add("@Month", SqlDbType.Int);
                command.Parameters.Add("@Year", SqlDbType.Int);
                String thangDuocChon = cbbThang.SelectedItem.ToString();
                String namDuocChon = cbbNam.SelectedItem.ToString();

                command.Parameters["@Month"].Value = int.Parse(thangDuocChon);
                command.Parameters["@Year"].Value = int.Parse(namDuocChon);



                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvLuongthang.DataSource = dt;
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec sp_TienluongNVtheothangpt @Month, @Year", connection);
                command.Parameters.Add("@Month", SqlDbType.Int);
                command.Parameters.Add("@Year", SqlDbType.Int);
                String thangDuocChon = cbbThang.SelectedItem.ToString();
                String namDuocChon = cbbNam.SelectedItem.ToString();

                command.Parameters["@Month"].Value = int.Parse(thangDuocChon);
                command.Parameters["@Year"].Value = int.Parse(namDuocChon);



                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvLuongthang.DataSource = dt;
            }
            else
            {
                var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("exec LINK.QuanLyDuAn.dbo.sp_TienluongNVtheothangpt @Month, @Year", connection);
            command.Parameters.Add("@Month", SqlDbType.Int);
            command.Parameters.Add("@Year", SqlDbType.Int);
            String thangDuocChon = cbbThang.SelectedItem.ToString();
            String namDuocChon = cbbNam.SelectedItem.ToString();

            command.Parameters["@Month"].Value = int.Parse(thangDuocChon);
            command.Parameters["@Year"].Value = int.Parse(namDuocChon);



            SqlDataAdapter sda = new SqlDataAdapter(command);
            dt = new DataTable();
            connection.Open();
            sda.Fill(dt);
            connection.Close();
            connection.Dispose();
            dgvLuongthang.DataSource = dt;
                
            }
            #region note
            /*var connectionName = string.Format("CN0{0}", branchId);
           var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
           connectionString = string.Format(connectionString, "sa", "1812816");
           var connection = new SqlConnection();
           connection.ConnectionString = connectionString;
           var command = new SqlCommand("exec sp_TienluongNVtheothang @Month, @Year", connection);
           command.Parameters.Add("@Month", SqlDbType.Int);
           command.Parameters.Add("@Year", SqlDbType.Int);
           String thangDuocChon = cbbThang.SelectedItem.ToString();
           String namDuocChon = cbbNam.SelectedItem.ToString();

           command.Parameters["@Month"].Value = int.Parse(thangDuocChon);
           command.Parameters["@Year"].Value = int.Parse(namDuocChon);



           SqlDataAdapter sda = new SqlDataAdapter(command);
           dt = new DataTable();
           connection.Open();
           sda.Fill(dt);
           connection.Close();
           connection.Dispose();
           dgvLuongthang.DataSource = dt;
           */
            #endregion


        }

        private void btnThongkeDA_Click(object sender, EventArgs e)
        {
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                string tungay = dtpTungay.Value.ToString("yyyyMMdd");
                string denngay = dtpdenngay.Value.ToString("yyyyMMdd");
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand(String.Format("exec LINK0.QuanLyDuAn.dbo.sp_Duan_FromDateToDatept '{0}', '{1}'", tungay, denngay), connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvDuantrongkhoang.DataSource = dt;
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                string tungay = dtpTungay.Value.ToString("yyyyMMdd");
                string denngay = dtpdenngay.Value.ToString("yyyyMMdd");
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand(String.Format("exec sp_Duan_FromDateToDatept '{0}', '{1}'", tungay, denngay), connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvDuantrongkhoang.DataSource = dt;
            }
            else
            {
                string tungay = dtpTungay.Value.ToString("yyyyMMdd");
                string denngay = dtpdenngay.Value.ToString("yyyyMMdd");
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand(String.Format("exec LINK.QuanLyDuAn.dbo.sp_Duan_FromDateToDatept '{0}', '{1}'", tungay, denngay), connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvDuantrongkhoang.DataSource = dt;
            }
            #region note
            /*string tungay = dtpTungay.Value.ToString("yyyyMMdd");
           string denngay = dtpdenngay.Value.ToString("yyyyMMdd");
           var connectionName = string.Format("CN0{0}", branchId);
           var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
           connectionString = string.Format(connectionString, "sa", "1812816");
           var connection = new SqlConnection();
           connection.ConnectionString = connectionString;
           var command = new SqlCommand(String.Format("exec sp_Duan_FromDateToDate '{0}', '{1}'",tungay,denngay), connection);
           SqlDataAdapter sda = new SqlDataAdapter(command);
           dt = new DataTable();
           connection.Open();
           sda.Fill(dt);
           connection.Close();
           connection.Dispose();
           dgvDuantrongkhoang.DataSource = dt;
          */
            #endregion


        }

        private void DisplayNhanVienThamgianhieuduannhat()
        {
            string query;
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                query = "exec LINK0.QuanLyDuAn.dbo.sp_NVthamgianhieuDA";
                connect(query, dgvNVthamgianhieuduan);
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                query = "exec sp_NVthamgianhieuDA";
                connect(branchId, query, dgvNVthamgianhieuduan);
            }
            else
            {
                query = "exec LINK.QuanLyDuAn.dbo.sp_NVthamgianhieuDA";
                connect(query, dgvNVthamgianhieuduan);
            }
            #region note
            // string query = "sp_NVthamgianhieuDA";
            // connect(branchId, query, dgvNVthamgianhieuduan);
            #endregion

        }
        private void btnThongkeNVthunhapcao_Click(object sender, EventArgs e)
        {
            if (cbbChiNhanh.SelectedIndex == 0)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec LINK0.QuanLyDuAn.dbo.sp_NVthunhapcaonhatpt @Year", connection);
                command.Parameters.Add("@Year", SqlDbType.Int);
                String namDuocChon = cbbNamthunhap.SelectedItem.ToString();

                command.Parameters["@Year"].Value = int.Parse(namDuocChon);



                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvNVthunhap.DataSource = dt;
            }
            else if (cbbChiNhanh.SelectedIndex == branchId)
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec sp_NVthunhapcaonhatpt @Year", connection);
                command.Parameters.Add("@Year", SqlDbType.Int);
                String namDuocChon = cbbNamthunhap.SelectedItem.ToString();

                command.Parameters["@Year"].Value = int.Parse(namDuocChon);



                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvNVthunhap.DataSource = dt;
            }
            else
            {
                var connectionName = string.Format("CN0{0}", branchId);
                var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                connectionString = string.Format(connectionString, "sa", "1812816");
                var connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                var command = new SqlCommand("exec LINK.QuanLyDuAn.dbo.sp_NVthunhapcaonhatpt @Year", connection);
                command.Parameters.Add("@Year", SqlDbType.Int);
                String namDuocChon = cbbNamthunhap.SelectedItem.ToString();

                command.Parameters["@Year"].Value = int.Parse(namDuocChon);



                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable();
                connection.Open();
                sda.Fill(dt);
                connection.Close();
                connection.Dispose();
                dgvNVthunhap.DataSource = dt;
            }

        }
        #region note
        /*     private void cbbNamthunhap_SelectedIndexChanged(object sender, EventArgs e)
     {
         if (cbbNamthunhap.SelectedIndex == -1) return;
         if (cbbChiNhanh.SelectedIndex == 0)
         {
             var connectionName = String.Format("CN0{0}", branchId);
             var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
             connectionString = String.Format(connectionString, "sa", "1812816");
             var connection = new SqlConnection();
             connection.ConnectionString = connectionString;
             var command = new SqlCommand("exec LINK.QuanLyDuAn.dbo.sp_NVthunhapcaonhat @Year", connection);
             command.Parameters.Add("@Year", SqlDbType.Int);
             String namDuocChon = cbbNamthunhap.SelectedItem.ToString();


             command.Parameters["@Year"].Value = int.Parse(namDuocChon);



             SqlDataAdapter sda = new SqlDataAdapter(command);
             dt = new DataTable();
             connection.Open();
             sda.Fill(dt);
             connection.Close();
             connection.Dispose();
             dgvNVthunhap.DataSource = dt;
         }
         else if (cbbChiNhanh.SelectedIndex == branchId)
         {
             var connectionName = String.Format("CN0{0}", branchId);
             var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
             connectionString = String.Format(connectionString, "sa", "1812816");
             var connection = new SqlConnection();
             connection.ConnectionString = connectionString;
             var command = new SqlCommand("exec sp_NVthunhapcaonhat @Year", connection);
             command.Parameters.Add("@Year", SqlDbType.Int);
             String namDuocChon = cbbNamthunhap.SelectedItem.ToString();


             command.Parameters["@Year"].Value = int.Parse(namDuocChon);



             SqlDataAdapter sda = new SqlDataAdapter(command);
             dt = new DataTable();
             connection.Open();
             sda.Fill(dt);
             connection.Close();
             connection.Dispose();
             dgvNVthunhap.DataSource = dt;
         }
         else
         {
             var connectionName = String.Format("CN0{0}", branchId);
             var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
             connectionString = String.Format(connectionString, "sa", "1812816");
             var connection = new SqlConnection();
             connection.ConnectionString = connectionString;
             var command = new SqlCommand("exec LINK.QuanLyDuAn.dbo.sp_NVthunhapcaonhat @Year", connection);
             command.Parameters.Add("@Year", SqlDbType.Int);
             String namDuocChon = cbbNamthunhap.SelectedItem.ToString();


             command.Parameters["@Year"].Value = int.Parse(namDuocChon);



             SqlDataAdapter sda = new SqlDataAdapter(command);
             dt = new DataTable();
             connection.Open();
             sda.Fill(dt);
             connection.Close();
             connection.Dispose();
             dgvNVthunhap.DataSource = dt;
         }
         var connectionName = String.Format("CN0{0}", branchId);
         var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
         connectionString = String.Format(connectionString, "sa", "1812816");
         var connection = new SqlConnection();
         connection.ConnectionString = connectionString;
         var command = new SqlCommand("exec sp_NVthunhapcaonhat @Year", connection);
         command.Parameters.Add("@Year", SqlDbType.Int);
         String namDuocChon = cbbNamthunhap.SelectedItem.ToString();


         command.Parameters["@Year"].Value = int.Parse(namDuocChon);



         SqlDataAdapter sda = new SqlDataAdapter(command);
         dt = new DataTable();
         connection.Open();
         sda.Fill(dt);
         connection.Close();
         connection.Dispose();
         dgvNVthunhap.DataSource = dt;
     }*/

        #endregion


        #endregion

        #region Taotaikhoan
        private void connect(int CN, string SqlString)
        {
            var connectionName = string.Format("CN0{0}", CN);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand(SqlString, connection);
            command.Connection = connection;
            command.Connection.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            int numRowAffected = command.ExecuteNonQuery();

            if (numRowAffected > 0)
            {
                MessageBox.Show("Cập nhập thành công", "Message");
                this.ResetText();
            }
            else
            {
                MessageBox.Show("Cập nhập không thành công");
            }
            connection.Close();
        }


        private void NhanVien(int CN)
        {
            var connectionName = string.Format("CN0{0}", CN);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("SELECT * FROM NhanVien", connection);
            command.Connection = connection;
            command.Connection.Open();
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    cbbMaNhanVien.Items.Add(sqlReader["MaNV"].ToString());
                }
                connection.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbMaNhanVien.SelectedIndex == -1) return;

            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("exec sp_TaoTaikhoan @LGNAME, @PASS, @USERNAME, @ROLE", connection);
            command.Parameters.Add("@LGNAME", SqlDbType.NVarChar);
            command.Parameters.Add("@PASS", SqlDbType.NVarChar);
            command.Parameters.Add("@USERNAME", SqlDbType.NVarChar);
            command.Parameters.Add("@ROLE", SqlDbType.NVarChar);

            String Tendn = txtTendangnhap.ToString();
            String mk = txtMatkhau.ToString();
            String manv = cbbMaNhanVien.SelectedItem.ToString();
            String nhom = cbbNhom.SelectedItem.ToString();


            command.Parameters["@LGNAME"].Value = Tendn;
            command.Parameters["@PASS"].Value = mk;
            command.Parameters["@USERNAME"].Value = manv;
            command.Parameters["@ROLE"].Value = nhom;


            SqlDataAdapter sda = new SqlDataAdapter(command);
            dt = new DataTable();
            connection.Open();
            sda.Fill(dt);
            connection.Close();
            connection.Dispose();
           

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}
