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
    /// Interaction logic for PageEditClient.xaml
    /// </summary>
    public partial class PageEditClient : Page
    {
        private Client _currentClient = new Client();
        public PageEditClient(Client selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentClient = selectedClient;
            DataContext = _currentClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.FIO))
                error.AppendLine("Укажите ФИО");
            if (string.IsNullOrWhiteSpace(_currentClient.PhoneNumber))
                error.AppendLine("Укажите Номер");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentClient.ClientID == 0)
                EStoreEntities.GetContext().Client.Add(_currentClient);
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
