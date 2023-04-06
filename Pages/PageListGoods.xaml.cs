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
    /// Interaction logic for PageListGoods.xaml
    /// </summary>
    public partial class PageListGoods : Page
    {
        public PageListGoods()
        {
            InitializeComponent();
            var _currentGoods = EStoreEntities.GetContext().Goods.ToList();
            LviewGoods.ItemsSource = _currentGoods;
        }
    }
}
