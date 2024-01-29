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
using Билет_20.DB;
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

            //    var t = new (int, string)[]
            //    {
            //        (1, "B111C5.jpeg"),
            //        (2, "E112C6.jpg"),
            //        (3, "T238C7.jpg"),
            //        (4, "M112C8.jpg"),
            //        (5, "M294G9.jpg"),
            //        (6, "N283K3.jpg"),
            //        (7, "L293S9.jpg"),
            //        (8, "M398S9.jpg"),
            //        (9, "S384K2.jpg"),
            //        (10, "K839K3.jpg"),
            //    };

            //    User10Context context = new User10Context();
            //    var products = context.Products.ToList();
            //    foreach(var tt in t)
            //    {
            //        var p = products.First(s => s.ProductId == tt.Item1);
            //        if (p != null)
            //            p.ProductPhoto = File.ReadAllBytes(tt.Item2);
            //    }
            //    context.SaveChanges();
            //}



        }
    }
}


