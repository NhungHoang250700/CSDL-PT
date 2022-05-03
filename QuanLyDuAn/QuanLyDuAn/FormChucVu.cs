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
    public partial class FormChucVu : Form
    {
        private int branchId = WorkingContext.Instance.CurrentBranchId;

        public FormChucVu()
        {
            InitializeComponent();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        public void DisplayChucvuInfo(DataRowView rowView)
        {
            try
            {
                txtMaCV.Text = rowView["MaCV"].ToString();
                txtTenCV.Text = rowView["TenCV"].ToString();
                nmTienluong.Value = decimal.Parse(rowView["TienLuong"].ToString());

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int Tienluong = (int)Convert.ToDouble(nmTienluong.Value);
            string SqlString = String.Format("exec usp_ThemChuVu N'{0}',N'{1}',{2} ", txtMaCV.Text,txtTenCV.Text,Tienluong);
            connect(branchId, SqlString);
            this.Dispose();

        }
    }
}
