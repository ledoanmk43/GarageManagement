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
    class KhoGaraDAL
    {
        private static KhoGaraDAL instance;
        internal static KhoGaraDAL Instance
        {
            get
            {
                if (instance == null) instance = new KhoGaraDAL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<KhoGaraDTO> GetListKho()
        {
            List<KhoGaraDTO> khoList = new List<KhoGaraDTO>();
             DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.khogarage");
            foreach (DataRow item in data.Rows)
            {
                KhoGaraDTO kho = new KhoGaraDTO(item);
                khoList.Add(kho);
            }
            return khoList;
        }

        public bool InsertKho( int iditem, string item , int slitem , DateTime? importeddate , DateTime? exporteddate)
        {
            string query = string.Format("insert dbo.khogarage ( iditem , item , slitem ,importeddate , exporteddate ) values ({0} , N'{1}' , {2} , '{3}' , '{4}')",  iditem, item, slitem , importeddate, exporteddate);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteKho( int iditem)
        {
            string query = string.Format("delete dbo.khogarage where  iditem ={0}", iditem);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateKho( int iditem, string item, int slitem, DateTime? importeddate, DateTime? exporteddate)
        {
            string query = string.Format("update dbo.khogarage set item = N'{0}' , slitem = {1} , importeddate = N'{2}', exporteddate = N'{3}'  where iditem = {4}",  item, slitem, importeddate, exporteddate, iditem);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<KhoGaraDTO> SearchKhoByNameAndID(string text)
        {
            List<KhoGaraDTO> khoList = new List<KhoGaraDTO>();
            string query = string.Format("select * from dbo.khogarage where dbo.GetUnsignString(item) like N'%' + dbo.GetUnsignString(N'{0}') + '%'", text);
            query += string.Format(" or iditem like N'%' + N'{0}' + '%'", text);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhoGaraDTO kho = new KhoGaraDTO(item);
                khoList.Add(kho);
            }

            return khoList;
        }
    }
}
