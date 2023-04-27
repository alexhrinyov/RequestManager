﻿using RequestManager.ViewModels;
using RequestManager.Views.Pages;
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
using System.Configuration;
using System.Collections.Specialized;

namespace RequestManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sAttr;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                sAttr = ConfigurationManager.AppSettings.Get("Key0");
                MessageBox.Show(sAttr);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }



    }
}
