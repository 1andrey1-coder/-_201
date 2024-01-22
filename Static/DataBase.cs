using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Билет_20;
using Билет_20.DB;

namespace Билет_20.Static
{
    internal class DataBase
    {
        static User10Context db;
        public static User10Context Instance()
        {
            if (db == null)
                db = new User10Context();
            return db;
        }

    }
}
