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
    /// Interaction logic for PageEditOrdersGoods.xaml
    /// </summary>
    public partial class PageEditOrdersGoods : Page
    {
        private OrdersGoods _currentOrdersGoods = new OrdersGoods();
        public PageEditOrdersGoods(OrdersGoods selectedOrdersGoods)
        {
            InitializeComponent();

            CmbOrdersID.ItemsSource = EStoreEntities.GetContext().Orders.ToList();
            CmbOrdersID.SelectedValuePath = "OrdersID";
            CmbOrdersID.DisplayMemberPath = "OrdersID";

            CmbGoodsID.ItemsSource = EStoreEntities.GetContext().Goods.ToList();
            CmbGoodsID.SelectedValuePath = "GoodsID";
            CmbGoodsID.DisplayMemberPath = "GName";

            if (selectedOrdersGoods != null)
                _currentOrdersGoods = selectedOrdersGoods;
            DataContext = _currentOrdersGoods;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (_currentOrdersGoods.OrdersID == null)
                error.AppendLine("Укажите код заказа!");
            if (_currentOrdersGoods.GoodsID == null)
                error.AppendLine("Укажите товар!");
            if (_currentOrdersGoods.Quantity == null)
                error.AppendLine("Укажите кол-во!");
            if (_currentOrdersGoods.Quantity < 1)
                error.AppendLine("Кол-во не может быть меньше 1!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentOrdersGoods.id == 0)
                EStoreEntities.GetContext().OrdersGoods.Add(_currentOrdersGoods);
            try
            {
                EStoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new PageTable());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
