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
    /// Interaction logic for PageEditDeliveryEmployee.xaml
    /// </summary>
    public partial class PageEditDeliveryEmployee : Page
    {
        private DeliveryEmployee _currentEmployee = new DeliveryEmployee();
        public PageEditDeliveryEmployee(DeliveryEmployee selectedDeliveryEmployee)
        {
            InitializeComponent();
            if (selectedDeliveryEmployee != null)
                _currentEmployee = selectedDeliveryEmployee;
            DataContext = _currentEmployee;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmployee.FIOEmployee))
                error.AppendLine("Укажите ФИО");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentEmployee.DeliveryEmployeeID == 0)
                EStoreEntities.GetContext().DeliveryEmployee.Add(_currentEmployee);
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
