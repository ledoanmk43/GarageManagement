using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GarageManagement_DTO;
using System.Security.Cryptography;

namespace GarageManagement_DAL
{
    public class AccountDAL
    {   
        private static AccountDAL instance;

        internal static AccountDAL Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private AccountDAL() { }
        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";
            foreach (byte item in hashData)
            {
                hashPass += item;
            }


            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });
            return result.Rows.Count > 0;
        }
        public AccountDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM account WHERE USERNAME = '" + userName + "'");
            foreach(DataRow item in data.Rows)
            {           
                return new AccountDTO(item);
            }
            return null;
        }
    }
}
