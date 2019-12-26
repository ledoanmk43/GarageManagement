﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.GarageManagement_DTO
{
    class VatLieuDTO
    {
        private int iditem;
        private string item;
        private int slitem;
        private DateTime? importeddate;


        public VatLieuDTO( int iditem , string item , int slitem , DateTime? iporteddate )
        {

            this.Iditem = iditem;
            this.Item = item;
            this.Slitem = slitem;
            this.Importeddate = iporteddate;

        }

        public VatLieuDTO(DataRow row)
        {
            this.Iditem = (int)row["iditem"];
            this.Item = row["item"].ToString();
            this.Slitem = (int)row["slitem"];
            this.Importeddate = (DateTime?)row["importeddate"];
        }


        public int Iditem { get => iditem; set => iditem = value; }
        public string Item { get => item; set => item = value; }
        public int Slitem { get => slitem; set => slitem = value; }
        public DateTime? Importeddate { get => importeddate; set => importeddate = value; }

    }
}
