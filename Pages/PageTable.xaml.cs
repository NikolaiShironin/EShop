using EShop.Classes;
using Microsoft.Office.Interop.Excel;
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
using Button = System.Windows.Controls.Button;
using Excel = Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;
using Word = Microsoft.Office.Interop.Word;

namespace EShop.Pages
{
    public partial class PageTable : Page
    {
        private EStoreEntities _context = new EStoreEntities();
        public PageTable()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = EStoreEntities.GetContext().OrdersGoods.ToList();
            OrderSelect.Text = Convert.ToInt32(OrderSelect.Text+1).ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEdit((sender as Button).DataContext as OrdersGoods));
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGridOrders.ItemsSource = EStoreEntities.GetContext().OrdersGoods.Where(x => x.Orders.Client.FIO.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            TxtSearch.Text = null;
            DGridOrders.ItemsSource = EStoreEntities.GetContext().OrdersGoods.ToList();
        }

        private void BtnToCategory_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditCategory(null));
        }

        private void BtnToClient_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditClient(null));
        }

        private void BtnToDelivery_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditDelivery(null));
        }

        private void BtnToDeliveryEmployee_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditDeliveryEmployee(null));
        }

        private void BtnToGoods_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditGoods(null));
        }

        private void BtnToOrders_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditOrders(null));
        }

        private void BtnToOrders_Goods_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditOrdersGoods(null));
        }
        private void BtnToStoreClick(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditStore(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var OrdersForRemoving = DGridOrders.SelectedItems.Cast<OrdersGoods>().ToList();
            if (MessageBox.Show($"Удалить {OrdersForRemoving.Count()} запись?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    EStoreEntities.GetContext().OrdersGoods.RemoveRange(OrdersForRemoving);
                    EStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridOrders.ItemsSource = EStoreEntities.GetContext().OrdersGoods.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void ToListGoods_Click(object sender, RoutedEventArgs e)
        {
                ClassFrame.frmObj.Navigate(new PageListGoods());
        }

        private void ToListStore_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageListStore());
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            var app = new Excel.Application();

            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet worksheet = app.Worksheets.Item[1];
            int indexRows = 1;
            worksheet.Cells[1][indexRows] = "Номер Заказа";
            worksheet.Cells[2][indexRows] = "Адресс магазина";
            worksheet.Cells[3][indexRows] = "Почта";
            worksheet.Cells[4][indexRows] = "Категория товара";
            worksheet.Cells[5][indexRows] = "Название товара";
            worksheet.Cells[6][indexRows] = "Цена";
            worksheet.Cells[7][indexRows] = "Кол-во";
            worksheet.Cells[8][indexRows] = "Тип получения";
            worksheet.Cells[9][indexRows] = "ФИО клиента";
            worksheet.Cells[10][indexRows] = "Номер клиента";
            worksheet.Cells[11][indexRows] = "Статус заказа";
            worksheet.Cells[12][indexRows] = "Дата Реализации заказа";
            var printItems = EStoreEntities.GetContext().OrdersGoods.ToList();
            foreach (var item in printItems)
            {
                worksheet.Cells[1][indexRows + 1] = item.Orders.OrdersID;
                worksheet.Cells[2][indexRows + 1] = item.Orders.Store.Adress;
                worksheet.Cells[3][indexRows + 1] = item.Orders.Store.EMail;
                worksheet.Cells[4][indexRows + 1] = item.Goods.Category.CName;
                worksheet.Cells[5][indexRows + 1] = item.Goods.GName;
                worksheet.Cells[6][indexRows + 1] = item.Goods.Price.ToString();
                worksheet.Cells[7][indexRows + 1] = item.Quantity.ToString();
                worksheet.Cells[8][indexRows + 1] = item.Orders.WayToGet.Type;
                worksheet.Cells[9][indexRows + 1] = item.Orders.Client.FIO;
                worksheet.Cells[10][indexRows + 1] = item.Orders.Client.PhoneNumber.ToString();
                worksheet.Cells[11][indexRows + 1] = item.Orders.Status.SName;
                worksheet.Cells[12][indexRows + 1] = item.Orders.DateTime.ToString();

                indexRows++;
            }
            worksheet.Cells[13][3].Formula = "Кол-во Проданного товара =";
            worksheet.Cells[14][3].Formula = $"=SUM(G2:G{indexRows})";
            worksheet.Cells[13][4].Formula = "Прибыль за все товары =";
            worksheet.Cells[14][4].Formula = $"=SUM(F2:F{indexRows})";

            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[12][indexRows], worksheet.Cells[1][1]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();
            app.Visible = true;
        }
        private void BtnWord_Click(object sender, RoutedEventArgs e)
        {
            int Select = Convert.ToInt32(OrderSelect.Text);

            var allOrders = _context.OrdersGoods.Where(x => x.OrdersID == Select).ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph orderParagrapth12 = document.Paragraphs.Add();
            Word.Range orderRange1 = orderParagrapth12.Range;

            foreach (var currentGoods in allOrders)
            {
                orderRange1.Text = "Чек по заказу №" + currentGoods.Orders.OrdersID.ToString();
                orderParagrapth12.set_Style("Заголовок");
            }
            orderRange1.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            orderRange1.InsertParagraphAfter();


            Word.Paragraph orderParagrapth = document.Paragraphs.Add();
            Word.Range orderRange = orderParagrapth.Range;

            foreach (var currentGoods in allOrders)
            {
                orderRange.Text = currentGoods.Orders.Client.FIO;
                orderParagrapth.set_Style("Заголовок");
            }
            orderRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            orderRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allOrders.Count() + 1, 7);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Фото";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Название";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Фирма";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Модель";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Цена, Р";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Кол-во";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Итог";

            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allOrders.Count(); i++)
            {
                var currentGood = allOrders[i];

                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                Word.InlineShape imageShape = cellRange.InlineShapes.AddPicture(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + currentGood.Goods.GImage);
                imageShape.Width = imageShape.Height = 40;
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = currentGood.Goods.GName;

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = currentGood.Goods.Firm;

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = currentGood.Goods.Model;

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = currentGood.Goods.Price.ToString();

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = currentGood.Quantity.ToString();

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = (currentGood.Goods.Price * currentGood.Quantity).ToString();
            }
            Word.Paragraph FinalPriceParagraph = document.Paragraphs.Add();
            Word.Range FinalPriceRange = FinalPriceParagraph.Range;
            int sum = 0;
            for (int i = 0; i < allOrders.Count(); i++)
            {
                var currentGoodss = allOrders[i];
                sum += Convert.ToInt32(allOrders[i].Goods.Price) * Convert.ToInt32(allOrders[i].Quantity);
            }
            FinalPriceRange.Text = "Итоговая цена: " + (sum).ToString() + "руб.";
            FinalPriceParagraph.set_Style("Заголовок");

            Word.Paragraph FinalPriceParagraph1 = document.Paragraphs.Add();
            Word.Range FinalPriceRange1 = FinalPriceParagraph.Range;

            foreach (var currentGoodsss in allOrders)
            {
                FinalPriceRange1.Text = "Дата реализация заказа: " + currentGoodsss.Orders.DateTime.ToString();
                orderParagrapth.set_Style("Заголовок");
            }
            orderRange.InsertParagraphAfter();
            application.Visible = true;
        }
    }
}