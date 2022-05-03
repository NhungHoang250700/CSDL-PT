using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDuAn
{
    public partial class FormNhanVien : Form
    {
        private int branchId = WorkingContext.Instance.CurrentBranchId;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void ChiNhanh(int CN)
        {
            var connectionName = string.Format("CN0{0}", CN);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("SELECT * FROM ChiNhanh", connection);
            command.Connection = connection;
            command.Connection.Open();
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    cbbMaCN.Items.Add(sqlReader["MaCN"].ToString());
                }
                connection.Close();
            }
        }

        private void ChucVu(int CN)
        {
            var connectionName = string.Format("CN0{0}", CN);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, "sa", "1812816");
            var connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            var command = new SqlCommand("SELECT * FROM ChucVu", connection);
            command.Connection = connection;
            command.Connection.Open();
            using (SqlDataReader sqlReader = command.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    cbbMaCV.Items.Add(sqlReader["MaCV"].ToString());
                }
                connection.Close();
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            ChiNhanh(WorkingContext.Instance.CurrentBranchId);
            cbbMaCN.Text = cbbMaCN.Items[0].ToString();
            ChucVu(WorkingContext.Instance.CurrentBranchId);
            //cbbMaCV.Text = cbbMaCV.Items[0].ToString();

        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string SqlString = String.Format("INSERT INTO NhanVien(MaNV,Ho,Ten,NgaySinh,DiaChi,MaCV,MaCN) VALUES(" + "'"+txtMaNV.Text+ "',"+"N'" +txtHo.Text+ "',"+ "N'" + txtTen.Text + "'," + "'"+dtpNgaysinh.Value+ "'," + "N'" +txtDiachi.Text + "'," + "'" + cbbMaCV.Text+ "'," + "'" + cbbMaCN.Text+"'" + ")") ;
            string SqlString = String.Format("exec usp_ThemNhanVien N'{0}',N'{1}','{2}',N'{3}','{4}','{5}'", txtHo.Text, txtTen.Text, dtpNgaysinh.Value, txtDiachi.Text, cbbMaCN.SelectedIndex, cbbMaCV.SelectedIndex);
            connect(cbbMaCN.SelectedIndex+1, SqlString);
            this.Dispose();
            

        }

        public void DisplayNhanVienInfo(DataRowView rowView)
        {
            try
            {
                txtMaNV.Text = rowView["MaNV"].ToString();
                txtHo.Text = rowView["Ho"].ToString();
                txtTen.Text = rowView["Ten"].ToString();
                dtpNgaysinh.Text = rowView["NgaySinh"].ToString();
                txtDiachi.Text = rowView["DiaChi"].ToString();
                cbbMaCV.SelectedIndex = -1;
                for (int index = 0; index < cbbMaCV.Items.Count; index++)
                {
                    if (cbbMaCV.Items[index].ToString() == rowView["MaCV"].ToString())
                    {
                        cbbMaCV.SelectedIndex = index;
                        break;
                    }
                }
                cbbMaCN.SelectedIndex = -1;
                for (int index = 0; index < cbbMaCN.Items.Count; index++)
                {
                    if (cbbMaCN.Items[index].ToString() == rowView["MaCN"].ToString())
                    {
                        cbbMaCN.SelectedIndex = index;
                        break;
                    }
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            string SqlString = String.Format("exec usp_ChinhSuaNhanVien '{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}'", txtMaNV.Text, txtHo.Text, txtTen.Text, dtpNgaysinh.Text, txtDiachi.Text, cbbMaCV.SelectedValue, cbbMaCN.SelectedValue);
            connect(cbbMaCN.SelectedIndex + 1, SqlString);

        }

        private void cbbMaCN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
