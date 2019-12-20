﻿using GarageManagement.GarageManagement_DTO;
using GarageManagement_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.GarageManagement_DAL
{
    class VatLieuDAL
    {
        private static VatLieuDAL instance;
        internal static VatLieuDAL Instance
        {
            get
            {
                if (instance == null) instance = new VatLieuDAL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<VatLieuDTO> GetListKho()
        {
            List<VatLieuDTO> khoList = new List<VatLieuDTO>();
             DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.vatlieu");
            foreach (DataRow item in data.Rows)
            {
                VatLieuDTO kho = new VatLieuDTO(item);
                khoList.Add(kho);
            }
            return khoList;
        }

        public VatLieuDTO GetListKhoById(int iditem)
        {
            VatLieuDTO kho = null;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.vatlieu where iditem = " + iditem);
            foreach (DataRow item in data.Rows)
            {
                kho = new VatLieuDTO(item);
                return kho;
            }
            return kho;
        }

        public bool InsertVatLieu( int iditem, string item , int slitem , DateTime? importeddate , DateTime? exporteddate)
        {
            string query = string.Format("insert dbo.vatlieu ( iditem , item , slitem ,importeddate , exporteddate ) values ({0} , N'{1}' , {2} , '{3}' , '{4}')",  iditem, item, slitem , importeddate, exporteddate);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteVatLieu( int iditem)
        {
            string query = string.Format("delete dbo.vatlieu where  iditem ={0}", iditem);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateVatLieu( int iditem, string item, int slitem, DateTime? importeddate, DateTime? exporteddate)
        {
            string query = string.Format("update dbo.vatlieu set item = N'{0}' , slitem = {1} , importeddate = N'{2}', exporteddate = N'{3}'  where iditem = {4}",  item, slitem, importeddate, exporteddate, iditem);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<VatLieuDTO> SearchVatLieuByNameAndID(string text)
        {
            List<VatLieuDTO> khoList = new List<VatLieuDTO>();
            string query = string.Format("select * from dbo.vatlieu where dbo.GetUnsignString(item) like N'%' + dbo.GetUnsignString(N'{0}') + '%'", text);
            query += string.Format(" or iditem like N'%' + N'{0}' + '%'", text);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                VatLieuDTO kho = new VatLieuDTO(item);
                khoList.Add(kho);
            }

            return khoList;
        }
    }
}