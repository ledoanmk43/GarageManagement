using GarageManagement_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace GarageManagement
{
    public partial class AdministratorForm : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; } //ChangeAccount(loginAccount.AccessLevel); }
        }
        public AdministratorForm(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;   
        }
        void ChangeAccount(int type)
        {
                
        }
        
    }
}
