using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Билет_20;
using Билет_20.DB;
using Билет_20.Static;
using User = Билет_20.DB.User;

namespace Билет_20.mvvm.vm
{
    internal class ListProductsVm: BaseVm
    {
        private List<User> users;


        public List<User> Users
        {
            get => users;
            set
            {
                users = value;
                Signal();
            }
        }

        public User SelectedUser { get; set; }

        public ListProductsVm()
        {
            Users = new List<User>();
            var db = Static.DataBase.Instance();
            Users = db.Users.ToList();

        }

    }
}
