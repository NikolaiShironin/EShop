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
using System.IO;
using Microsoft.Win32;
using System.Web.UI.WebControls;

namespace EShop.Pages
{
    /// <summary>
    /// Interaction logic for PageEditStore.xaml
    /// </summary>
    public partial class PageEditStore : Page
    {
        private Store _currentStore = new Store();
        string imgLoc = "пусто";
        public PageEditStore(Store selectedStore)
        {
            InitializeComponent();

            if (selectedStore != null)
                _currentStore = selectedStore;
            DataContext = _currentStore;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentStore.Adress))
                error.AppendLine("Укажите Адрес");
            if (_currentStore.EMail == null)
                error.AppendLine("Укажите Почту!");
            if (_currentStore.Code == null)
                error.AppendLine("Укажите Код!");
            if (_currentStore.Code < 0)
                error.AppendLine("Код не может быть отрицательным!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentStore.StoreID == 0)
                EStoreEntities.GetContext().Store.Add(_currentStore);
            try
            {
                if (imgLoc != null && imgLoc != "пусто")
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string filename = imgLoc.Substring(imgLoc.LastIndexOf('\\') + 1);
                    _currentStore.Picture = String.Concat("/ResPhoto/", filename);
                }
                EStoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new PageTable());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ImageLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*",
                    Title = "Выберите фото/изображение лекарства"
                };
                if (dlg.ShowDialog() == true)
                {
                    imgLoc = dlg.FileName.ToString();
                    imageArtist.Source = new BitmapImage(new Uri(imgLoc));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
