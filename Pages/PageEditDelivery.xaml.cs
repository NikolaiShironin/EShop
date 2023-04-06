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
    /// Interaction logic for PageEditDelivery.xaml
    /// </summary>
    public partial class PageEditDelivery : Page
    {
        private Delivery _currentDelivery = new Delivery();
        public PageEditDelivery(Delivery selectedDelivery)
        {
            InitializeComponent();
            CmbEmployee.ItemsSource = EStoreEntities.GetContext().DeliveryEmployee.ToList();
            CmbEmployee.SelectedValuePath = "DeliveryEmployeeID";
            CmbEmployee.DisplayMemberPath = "FIOEmployee";

            if (selectedDelivery != null)
                _currentDelivery = selectedDelivery;
            DataContext = _currentDelivery;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentDelivery.Adress))
                error.AppendLine("Укажите Адресс получателя");
            if (_currentDelivery.DeliveryEmployeeID == null)
                error.AppendLine("Укажите Доставщика!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentDelivery.DeliveryID == 0)
                EStoreEntities.GetContext().Delivery.Add(_currentDelivery);
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
