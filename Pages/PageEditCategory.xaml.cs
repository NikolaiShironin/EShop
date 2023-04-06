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
    /// Interaction logic for PageEditCategory.xaml
    /// </summary>
    public partial class PageEditCategory : Page
    {
        private Category _currentCategory = new Category();
        public PageEditCategory(Category selectedCategory)
        {
            InitializeComponent();

            if (selectedCategory != null)
                _currentCategory = selectedCategory;
            DataContext = _currentCategory;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentCategory.CName))
                error.AppendLine("Укажите категорию!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentCategory.CategoryID == 0)
                EStoreEntities.GetContext().Category.Add(_currentCategory);
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
