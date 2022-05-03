using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;



namespace QuanLyDuAn
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }
       

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string branch, loginName, password;
            if(txtTendangnhap.Text == "" || txtMatkhau.Text=="")
            {
                MessageBox.Show("Vui lòng nhập thông tin đăng nhập");
            }
            if (cbbChiNhanh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh");
            }
            branch = cbbChiNhanh.Text;
            int branchId = cbbChiNhanh.SelectedIndex + 1;
            loginName = txtTendangnhap.Text;
            password = txtMatkhau.Text;
            WorkingContext.Instance.CurrentBranch = branch;
            WorkingContext.Instance.CurrentBranchId = branchId;
            WorkingContext.Instance.CurrentLoginName = loginName;
            var connectionName = string.Format("CN0{0}", branchId);
            var connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            connectionString = string.Format(connectionString, loginName, password);
            WorkingContext.Instance.Initialize(connectionString);
            try
            {
                var dbContext = WorkingContext.Instance._dbContext;
                var loginInfo = dbContext.Database.SqlQuery<LoginInfo>("exec sp_GetLoginInfo @p0", loginName).FirstOrDefault();
                WorkingContext.Instance.CurrentLoginInfo = loginInfo;
                this.DialogResult = DialogResult.OK;
                MainForm f1 = new MainForm();
                f1.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai thông tin đăng nhập \r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
