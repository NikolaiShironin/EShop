﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using EShop.Classes;
using EShop.Pages;

namespace EShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.frmObj = frmMain;
            frmMain.Navigate(new Pages.PageTable());
        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {
            if (frmMain.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
            if (frmMain.CanGoForward)
            {
                BtnForward.Visibility = Visibility.Visible;
            }
            else
            {
                BtnForward.Visibility = Visibility.Hidden;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoBack();
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            frmMain.GoForward();
        }
    }
}
