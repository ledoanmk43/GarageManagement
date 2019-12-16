using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.GarageManagement_DTO
{
    class KhoGaraDTO
    {
        private int iditem;
        private string item;
        private int slitem;
        private DateTime? importeddate;
        private DateTime? exporteddate;

        public KhoGaraDTO( int iditem , string item , int slitem , DateTime? iporteddate ,DateTime? exporteddate)
        {

            this.Iditem = iditem;
            this.Item = item;
            this.Slitem = slitem;
            this.Importeddate = iporteddate;
            this.Exporteddate = exporteddate;
        }

        public KhoGaraDTO(DataRow row)
        {
            this.Iditem = (int)row["iditem"];
            this.Item = row["item"].ToString();
            this.Slitem = (int)row["slitem"];
            this.Importeddate = (DateTime?)row["importeddate"];
            this.Exporteddate = (DateTime?)row["exporteddate"];
        }


        public int Iditem { get => iditem; set => iditem = value; }
        public string Item { get => item; set => item = value; }
        public int Slitem { get => slitem; set => slitem = value; }
        public DateTime? Importeddate { get => importeddate; set => importeddate = value; }
        public DateTime? Exporteddate { get => exporteddate; set => exporteddate = value; }
    }
}
