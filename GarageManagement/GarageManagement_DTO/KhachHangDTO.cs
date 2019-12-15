using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement_DTO
{
    class KhachHangDTO
    {
        private int id;
        private string customername;
        private string carnumber;
        private string carbrand;
        private string address;
        private int phone;
        private float debt;
        private DateTime? createddate;

        public KhachHangDTO(int id , string customername, string carnumber, string carbrand, string address, int phone , float debt, DateTime? createddate)
        {
            this.Id = id;
            this.Customername = customername;
            this.Carnumber = carnumber;
            this.Carbrand = carbrand;
            this.Address = address;
            this.Phone = phone;
            this.Debt = debt;
            this.Createddate = createddate;
        }

        public KhachHangDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Customername = row["CUSTOMERNAME"].ToString();
            this.Carnumber = row["carnumber"].ToString();
            this.Carbrand = row["carbrand"].ToString();
            this.Address = row["address"].ToString();
            this.Phone= (int)row["phone"];
            this.Createddate = (DateTime?)row["createddate"];
            this.Debt = (float)Convert.ToDouble(row["debt"].ToString());           
        }
        public int Id { get => id; set => id = value; }
        public string Customername { get => customername; set => customername = value; }
        public string Carnumber { get => carnumber; set => carnumber = value; }
        public string Carbrand { get => carbrand; set => carbrand = value; }
        public string Address { get => address; set => address = value; }
        public float Debt { get => debt; set => debt = value; }
        public DateTime? Createddate { get => createddate; set => createddate = value; }
        public int Phone { get => phone; set => phone = value; }
    }
}
