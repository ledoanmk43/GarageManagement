using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement_DTO
{
    public class AccountDTO
    {
        public AccountDTO(string id, string userName, int accesslevel, string Pass)
        {
            this.ID = id;
            this.UserName = userName;
            this.Password = Pass;
            this.AccessLevel = accesslevel;
        }
        public AccountDTO(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.UserName = row["userName"].ToString();
            this.Password = row["Pass"].ToString();
            this.AccessLevel = (int)row["accesslevel"];
        }

        private string id;  
        public string ID
        {
            get { return id; }
            set { id = value; }
        }


        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }


        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        private int access_level;
        public int AccessLevel
        {
            get { return access_level; }
            set { access_level = value; }
        }

    }
}
