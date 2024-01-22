using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Билет_20.Pages;
using Билет_20.DB;

namespace Билет_20.mvvm.vm
{
    class MainVm: BaseVm
    {
        public string UserFIO
        {
            get => $"{User.UserSurname} {User.UserName} {User.UserFather}";
        }


    }
}
