using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Билет_20;
using Билет_20.Pages;
using Билет_20.Static;

namespace Билет_20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = PageNavigator.Get();
            PageNavigator.Get().CurrentPage = new LoginPage();

            //var t = new (int, string)[]
            //{
            //    (3, "1.jpg"),
            //    (5, "2.jpg"),
            //    (6, "3.jpg"),
            //    (1, "m1.jpg"),
            //    (2, "m2.jpg"),
            //    (4, "m3.jpg"),
            //};

            //User10Context context = new User10Context();
            //var products = context.Users.ToList();
            //foreach(var tt in t)
            //{
            //    var p = products.First(s => s.Userid == tt.Item1);
            //    if (p != null)
            //        p.UserPhoto = File.ReadAllBytes(tt.Item2);
            //}
            //context.SaveChanges();
        }


        
    }
}
