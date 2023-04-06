using EShop.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PageEditGoods.xaml
    /// </summary>
    public partial class PageEditGoods : Page
    {
        private Goods _currentGoods = new Goods();
        string imgLoc = "пусто";
        public PageEditGoods(Goods selectedGoods)
        {
            InitializeComponent();
            CmbCategory.ItemsSource = EStoreEntities.GetContext().Category.ToList();
            CmbCategory.SelectedValuePath = "CategoryID";
            CmbCategory.DisplayMemberPath = "CName";

            if (selectedGoods != null)
                _currentGoods = selectedGoods;
            DataContext = _currentGoods;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentGoods.GName))
                error.AppendLine("Укажите Название товара");
            if (_currentGoods.CategoryID == null)
                error.AppendLine("Укажите Категорию!");
            if (_currentGoods.Firm == null)
                error.AppendLine("Укажите Магазин!");
            if (_currentGoods.Model == null)
                error.AppendLine("Укажите Магазин!");
            if (_currentGoods.Price == null)
                error.AppendLine("Укажите Цену!");
            if (_currentGoods.Price < 50)
                error.AppendLine("Цена не может быть меньше 50р!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentGoods.GoodsID == 0)
                EStoreEntities.GetContext().Goods.Add(_currentGoods);
            try
            {
                if (imgLoc != null && imgLoc != "пусто")
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    string filename = imgLoc.Substring(imgLoc.LastIndexOf('\\') + 1);
                    _currentGoods.GImage = String.Concat("/ResPhoto/", filename);
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
