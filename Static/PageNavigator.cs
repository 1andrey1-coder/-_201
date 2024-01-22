using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Билет_20.Static
{
    internal class PageNavigator : INotifyPropertyChanged
    {
        private PageNavigator() { }
        static PageNavigator ins = new PageNavigator();

        public static PageNavigator Get() => ins;

        private Page currentPage;

        public Page CurrentPage 
        { 
            get => currentPage;
            set
            {
                currentPage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentPage"));
            }

        }
        public event EventHandler<Page> CurrentPageChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
