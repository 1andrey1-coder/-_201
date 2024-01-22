using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Билет_20.Static
{
    internal partial class User
    {
        static Билет_20.DB.User logged = new();

        public static Билет_20.DB.User Loggen
        {
            get => logged;
            set
            {
                logged = value;
                LoggedChanged?.Invoke(null, value);
            }
        }
        public static event EventHandler<Билет_20.DB.User> LoggedChanged;
    }
}
