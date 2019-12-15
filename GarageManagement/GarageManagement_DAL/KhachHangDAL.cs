using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageManagement_DTO;

namespace GarageManagement_DAL
{
    class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangDAL();
                return KhachHangDAL.instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<KhachHangDTO>  GetListKhachHang()
        {
            List<KhachHangDTO> khachhangList = new List<KhachHangDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.hosokhachhang ");
            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO khachhang = new KhachHangDTO(item);
                khachhangList.Add(khachhang);
            }
            return khachhangList;
        }

        public bool InsertKhachHang(int id , string carnumber ,string customername , string carbrand , string address , int phone , DateTime createdate , float debt)
        {
            string query = "insert dbo.hosokhachhang (id , customername , carnumber , carbrand , address , phone , createddate , debt )";
            query += string.Format("values ( {6} , N'{0}' ,N'{7}', N'{1}' , N'{2}' , {3} , N'{4}' , {5} )", customername, carbrand, address, phone, createdate, debt, id , carnumber);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateKhachHang(string customername, string carbrand, string address, int phone, DateTime createdate, float debt , int id , string soxe)
        {
            string query = "update dbo.hosokhachhang set ";
            query += string.Format(" customername = N'{0}' , carbrand =N'{1}' , address = N'{2}' , phone = N'{3}' , createddate = N'{4}' , debt = {5} where id = {6} and carnumber = {7} ", customername, carbrand, address, phone, createdate, debt , id , soxe);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteKhachHang( int id, string soxe)
        {
            string query = string.Format("delete dbo.hosokhachhang where id = {0} and carnumber = {1}", id ,soxe);     
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<KhachHangDTO> SearchKhachHangByNameAndID(string name)
        {
            List<KhachHangDTO> khachhangList = new List<KhachHangDTO>();
            string query = string.Format("select * from dbo.hosokhachhang where dbo.GetUnsignString(customername) like N'%' + dbo.GetUnsignString(N'{0}') + '%'", name);
            query += string.Format(" or id like N'%' + N'{0}' + '%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO khachhang = new KhachHangDTO(item);
                khachhangList.Add(khachhang);
            }
            return khachhangList;
        }
    }
}
