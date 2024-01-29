using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Билет_20.DB;

namespace Билет_20.Static
{
    internal partial class AuthUser
    {
        static User logged = new();

        public static User Loggen
        {
            get => logged;
            set
            {
                logged = value;
                LoggedChanged?.Invoke(null, value);
            }
        }
        public static event EventHandler<User> LoggedChanged;
    }
}
