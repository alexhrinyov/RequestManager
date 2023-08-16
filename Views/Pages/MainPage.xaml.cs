using RequestManager.Models.Config;
using RequestManager.ViewModels;
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

namespace RequestManager.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            //Делаем текущий год и текущий месяц выбранными по умолчанию
            YearsBox.SelectedIndex = 0;
            MonthsBox.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((RequestViewModel)this.DataContext).ShowLinesWindowCommand.Execute(null);
        }
    }
}
