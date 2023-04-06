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
    /// Interaction logic for PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        private OrdersGoods _currentOrder = new OrdersGoods();
        public PageEdit(OrdersGoods selectedOrder)
        {
            InitializeComponent();
            CmbOrdersID.ItemsSource = EStoreEntities.GetContext().Orders.ToList();
            CmbOrdersID.SelectedValuePath = "OrdersID";
            CmbOrdersID.DisplayMemberPath = "OrdersID";

            CmbDateTime.ItemsSource = EStoreEntities.GetContext().Orders.ToList();
            CmbDateTime.SelectedValuePath = "OrdersID";
            CmbDateTime.DisplayMemberPath = "DateTime";

            CmbStoreAdress.ItemsSource = EStoreEntities.GetContext().Store.ToList();
            CmbStoreAdress.SelectedValuePath = "StoreID";
            CmbStoreAdress.DisplayMemberPath = "Adress";

            CmbEMail.ItemsSource = EStoreEntities.GetContext().Store.ToList();
            CmbEMail.SelectedValuePath = "StoreID";
            CmbEMail.DisplayMemberPath = "EMail";

            CmbCName.ItemsSource = EStoreEntities.GetContext().Category.ToList();
            CmbCName.SelectedValuePath = "CategoryID";
            CmbCName.DisplayMemberPath = "CName";

            CmbGName.ItemsSource = EStoreEntities.GetContext().Goods.ToList();
            CmbGName.SelectedValuePath = "GoodsID";
            CmbGName.DisplayMemberPath = "GName";

            CmbPrice.ItemsSource = EStoreEntities.GetContext().Goods.ToList();
            CmbPrice.SelectedValuePath = "GoodsID";
            CmbPrice.DisplayMemberPath = "Price";

            CmbType.ItemsSource = EStoreEntities.GetContext().WayToGet.ToList();
            CmbType.SelectedValuePath = "WayToGetID";
            CmbType.DisplayMemberPath = "Type";

            CmbAdress.ItemsSource = EStoreEntities.GetContext().Delivery.ToList();
            CmbAdress.SelectedValuePath = "DeliveryID";
            CmbAdress.DisplayMemberPath = "Adress";

            CmbFIO.ItemsSource = EStoreEntities.GetContext().Client.ToList();
            CmbFIO.SelectedValuePath = "ClientID";
            CmbFIO.DisplayMemberPath = "FIO";

            CmbFIOEmployee.ItemsSource = EStoreEntities.GetContext().DeliveryEmployee.ToList();
            CmbFIOEmployee.SelectedValuePath = "DeliveryEmployeeID";
            CmbFIOEmployee.DisplayMemberPath = "FIOEmployee";

            CmbPhoneNumber.ItemsSource = EStoreEntities.GetContext().Client.ToList();
            CmbPhoneNumber.SelectedValuePath = "ClientID";
            CmbPhoneNumber.DisplayMemberPath = "PhoneNumber";

            CmbSName.ItemsSource = EStoreEntities.GetContext().Status.ToList();
            CmbSName.SelectedValuePath = "StatusID";
            CmbSName.DisplayMemberPath = "SName";

            if (selectedOrder != null)
                _currentOrder = selectedOrder;
            DataContext = _currentOrder;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (_currentOrder.Quantity < 1)
                error.AppendLine("Кол-во не может быть меньше 1!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentOrder.id == 0)
                EStoreEntities.GetContext().OrdersGoods.Add(_currentOrder);
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
