using GarageManagement.GarageManagement_DTO;
using GarageManagement_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.GarageManagement_DAL
{
    class PhieuThuTienDAL
    {
        private static PhieuThuTienDAL instance;

        internal static PhieuThuTienDAL Instance
        {
            get
            {
                if (instance == null) instance = new PhieuThuTienDAL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<PhieuThuTienDTO> GetListPhieuThuTien()
        {
            List<PhieuThuTienDTO> phieuthutienList = new List<PhieuThuTienDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.phieuthutien");
            foreach (DataRow item in data.Rows)
            {
                PhieuThuTienDTO phieuthutien = new PhieuThuTienDTO(item);
                phieuthutienList.Add(phieuthutien);
            }
            return phieuthutienList;
        }


        public bool InsertPhieuThuTien(int idptt, int idkhachhang, int carnumber, DateTime? createddate, float sotienthu)
        {
            string query = string.Format("insert dbo.phieuthutien ( idptt, idkhachhang, carnumber, createddate, sotienthu ) ");
            query += string.Format("values ({0} , {1} , {2} , N'{3}' , '{4}' ) ", idptt, idkhachhang, carnumber, createddate, sotienthu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdatePhieuThuTien(int idptt, int idkhachhang, int carnumber, DateTime? createddate, float sotienthu)
        {
            string query = string.Format("update dbo.phieuthutien set");
            query += string.Format(" idkhachhang = {0} , carnumber = {1} , createddate = '{2}' , sotienthu = {3} where idptt = {4} ",  idkhachhang, carnumber, createddate, sotienthu , idptt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeletePhieuThuTien(int idptt)
        {
            string query = string.Format("delete dbo.phieuthutien where idptt ={0}", idptt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
