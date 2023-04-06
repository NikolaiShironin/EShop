using EShop.Classes;
using System;
using System.Collections.Generic;
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

namespace EShop.Pages
{
    /// <summary>
    /// Interaction logic for PageListStore.xaml
    /// </summary>
    public partial class PageListStore : Page
    {
        public PageListStore()
        {
            InitializeComponent();
            var _currentStore = EStoreEntities.GetContext().Store.ToList();
            LviewStore.ItemsSource = _currentStore;
        }
    }
}
