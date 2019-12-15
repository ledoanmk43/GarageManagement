using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagement.GarageManagement_DAL
{
    class KhoGaraDAL
    {
        private static KhoGaraDAL instance;
        public static KhoGaraDAL Instance
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


    }
}
