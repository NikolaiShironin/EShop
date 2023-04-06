using EShop.Classes;
using MahApps.Metro.Controls;
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
    /// Interaction logic for PageEditOrders.xaml
    /// </summary>

    public partial class PageEditOrders : Page
    {
        private Orders _currentOrders = new Orders();
        public PageEditOrders(Orders selectedOrders)
        {
            InitializeComponent();

            CmbTxtStoreID.ItemsSource = EStoreEntities.GetContext().Store.ToList();
            CmbTxtStoreID.SelectedValuePath = "StoreID";
            CmbTxtStoreID.DisplayMemberPath = "Adress";

            CmbTxtWayToGetID.ItemsSource = EStoreEntities.GetContext().WayToGet.ToList();
            CmbTxtWayToGetID.SelectedValuePath = "WayToGetID";
            CmbTxtWayToGetID.DisplayMemberPath = "Type";

            CmbDeliveryID.ItemsSource = EStoreEntities.GetContext().Delivery.ToList();
            CmbDeliveryID.SelectedValuePath = "DeliveryID";
            CmbDeliveryID.DisplayMemberPath = "DeliveryID";

            CmbClientID.ItemsSource = EStoreEntities.GetContext().Client.ToList();
            CmbClientID.SelectedValuePath = "ClientID";
            CmbClientID.DisplayMemberPath = "FIO";

            CmbStatusID.ItemsSource = EStoreEntities.GetContext().Status.ToList();
            CmbStatusID.SelectedValuePath = "StatusID";
            CmbStatusID.DisplayMemberPath = "SName";

            if (selectedOrders != null)
                _currentOrders = selectedOrders;
            DataContext = _currentOrders;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (_currentOrders.StoreID== null)
                error.AppendLine("Укажите Магазин!");
            if (_currentOrders.WayToGetID == null)
                error.AppendLine("Укажите Способ получения!");
            if (_currentOrders.DeliveryID == null)
                error.AppendLine("Укажите Код доставки!");
            if (_currentOrders.ClientID == null)
                error.AppendLine("Укажите Клиента!");
            if (_currentOrders.StatusID == null)
                error.AppendLine("Укажите Статус заказа!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentOrders.OrdersID == 0)
                EStoreEntities.GetContext().Orders.Add(_currentOrders);
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

        private void DP1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
                string t = cboTP.Text;
                string d = DP1.Text;
                DateTime dt = DateTime.Parse(d +" "+ t);
                TxtDateTime.Text= dt.ToString();
        }
    }
}
