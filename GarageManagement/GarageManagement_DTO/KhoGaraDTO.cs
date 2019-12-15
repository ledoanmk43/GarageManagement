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
        private string carnumber;
        private int iditem;
        private string item;
        private int slitem;

        public KhoGaraDTO(string carnumber , int iditem , string item , int slitem)
        {
            this.Carnumber = carnumber;
            this.Iditem = iditem;
            this.Item = item;
            this.Slitem = slitem;
        }

        public KhoGaraDTO(DataRow row)
        {
            this.Carnumber = row["carnumber"].ToString();
            this.Iditem = (int)row["iditem"];
            this.Item = row["item"].ToString();
            this.Slitem = (int)row["slitem"];
        }

        public string Carnumber { get => carnumber; set => carnumber = value; }
        public int Iditem { get => iditem; set => iditem = value; }
        public string Item { get => item; set => item = value; }
        public int Slitem { get => slitem; set => slitem = value; }
    }
}
