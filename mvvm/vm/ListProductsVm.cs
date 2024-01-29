using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Билет_20.DB;
using Билет_20.Static;

namespace Билет_20.mvvm.vm
{
    internal class ListProductsVm : BaseVm
    {
        private List<Product> products;
        private string searchText = "";
       

        public List<string> SortValues { get; set; }
        public List<Manufactuer> Manufactuers { get; set; }

        private string selectedSortValue;

        public string SelectedSortValue
        {
            get => selectedSortValue;
            set
            {
                selectedSortValue = value;
                Search();
            }
        }
        private Manufactuer selectedManufactuer;

        public Manufactuer SelectedManufactuer
        {
            get => selectedManufactuer;
            set
            {
                selectedManufactuer = value;
                Search();
            }
        }

       

        public List<Product> Products
        {
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }
        byte[] defaultImage;

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }


        public Product SelectedProduct { get; set; }

        public ListProductsVm()
        {
            LoadDefaultImage();

            //Manufactuers = DataBase.Instance().Manufactuers.ToList();

            SortValues = new List<string>(new string[] { "По возрастанию", "По убыванию"});

            try
            {
                Manufactuers = DataBase.Instance().Manufactuers.ToList();
                Manufactuers.Insert(0, new Manufactuer { ManufactuerTitle = "Все производители" });
                SelectedManufactuer = Manufactuers.First();
            }
            catch { }
            //Products = new List<Product>();
            //var db = DataBase.Instance();
            //Products = db.Products.ToList();
            Search();
        }

        private void LoadDefaultImage()
        {
            var stream = Application.GetResourceStream(new Uri("Image/picture.png", UriKind.Relative));
            defaultImage = new byte[stream.Stream.Length];
            stream.Stream.Read(defaultImage, 0, defaultImage.Length);
        }

        private void Search()
        {
            try
            {
                var db = Static.DataBase.Instance();
                int productCount = db.Products.Count();

                var products = db.Products.
                    Include(s => s.ProductManufactuer).
                    Include(s => s.ProductCategory).
                    Include(s => s.ProductProvider);
                IQueryable<Product> filterProduct;

                if (SelectedManufactuer.ManufactuerId != 0)
                    filterProduct = products.Where(s => s.ProductManufactuerId == SelectedManufactuer.ManufactuerId);
                else
                    filterProduct = products;
                filterProduct = filterProduct.Where(s => s.ProductManufactuer.ManufactuerTitle.Contains(SearchText) ||
                s.ProductProvider.ProviderTitle.Contains(SearchText) ||
                s.ProductTitle.Contains(SearchText) ||
                s.ProductCategory.CategoryTitle.Contains(SearchText) ||
                s.ProductArticle.Contains(SearchText)
                );

                if (SelectedSortValue == "По возрастанию")
                    Products = filterProduct.OrderBy(s => s.ProductCost).ToList();
                else
                    Products = filterProduct.OrderByDescending(s => s.ProductCost).ToList();
                 
                
                foreach (var item in Products)
                {
                    if(item.ProductPhoto == null)
                    {
                        item.ProductPhoto = defaultImage;
                    }
                }

                if (Products.Count == 0)
                {
                    MessageBox.Show("Насальника-ошибка-падла!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
