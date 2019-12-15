using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GarageManagement_DAL;
using GarageManagement_DTO;

namespace GarageManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txbUsername.Select();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text;
            string passWord = txbPassword.Text;
            if (Login(userName, passWord))
            {
                try
                {
                    Account loginAccount = AccountDAL.Instance.GetAccountByUserName(userName);
                    AdministratorForm adminFrom = new AdministratorForm(loginAccount);
                    this.Hide();
                    adminFrom.ShowDialog();
                    this.Show();
                }
                catch(Exception)
                {
                    MessageBox.Show("Đã có lỗi xảy ra!");
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }

        }

       bool Login(string userName,string passWord)
        {
            
            return AccountDAL.Instance.Login(userName, passWord);
        }
    }
}
