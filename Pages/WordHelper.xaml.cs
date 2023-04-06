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
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using EShop.Classes;


namespace EShop.Pages
{
    /// <summary>
    /// Interaction logic for WordHelper.xaml
    /// </summary>
    public partial class WordHelper : Page
    {
        private FileInfo _fileInfo;
        public WordHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("Файл не найден");
            }
        }
        private OrdersGoods _currentOrdersGoods = new OrdersGoods();
        public WordHelper(OrdersGoods selectordersGoods)
        {
            InitializeComponent();
            CmbOrdersID.ItemsSource = EStoreEntities.GetContext().Orders.ToList();
            CmbOrdersID.SelectedValuePath = "OrdersID";
            CmbOrdersID.DisplayMemberPath = "OrdersID";

            StoreAdress.ItemsSource = EStoreEntities.GetContext().Store.ToList();
            StoreAdress.SelectedValuePath = "StoreID";
            StoreAdress.DisplayMemberPath = "Adress";

            EMail.ItemsSource = EStoreEntities.GetContext().Store.ToList();
            EMail.SelectedValuePath = "StoreID";
            EMail.DisplayMemberPath = "EMail";

            Types.ItemsSource = EStoreEntities.GetContext().WayToGet.ToList();
            Types.SelectedValuePath = "WayToGetID";
            Types.DisplayMemberPath = "Type";

            FIO.ItemsSource = EStoreEntities.GetContext().Client.ToList();
            FIO.SelectedValuePath = "ClientID";
            FIO.DisplayMemberPath = "FIO";

            CName.ItemsSource = EStoreEntities.GetContext().Category.ToList();
            CName.SelectedValuePath = "CategoryID";
            CName.DisplayMemberPath = "CName";

            GName.ItemsSource = EStoreEntities.GetContext().Goods.ToList();
            GName.SelectedValuePath = "GoodsID";
            GName.DisplayMemberPath = "GName";

            Price.ItemsSource = EStoreEntities.GetContext().Goods.ToList();
            Price.SelectedValuePath = "GoodsID";
            Price.DisplayMemberPath = "Price";

            if (selectordersGoods != null)
                _currentOrdersGoods = selectordersGoods;
            DataContext = _currentOrdersGoods;
        }
        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHelper("C:\\Users\\admin\\Desktop\\EShop\\Documents\\PriceList.docx");
            var items = new Dictionary<string, string>
            {
                { "<STOREADRES>", StoreAdress.Text },
                { "<EMAIL>", EMail.Text},
                { "<TYPE>", Types.Text},
                { "<FIO>", FIO.Text },
                { "<CNAME>", CName.Text},
                { "<GNAME>", GName.Text},
                { "<PRICE>", Price.Text },
                { "<QUANTITY>", Quantity.Text},

            };
            helper.Process(items);
        }
        internal bool Process(Dictionary<string, string> items)
        {
            try
            {
                var app = new Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;
                app.Documents.Open(file);
                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;
                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;
                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
    }
}
