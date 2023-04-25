using RequestManager.Infrastructure.Commands;
using RequestManager.ViewModels.Base;
using RequestManager.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace RequestManager.ViewModels
{
    internal class RequestViewModel: ViewModel
    {
        #region Свойства
        //private int id;
        //private string date;
        //private string sender;
        //public int Id { get { return id; } }
        //public string Date 
        //{
        //    get { return date; }
        //    set => Set(ref date, value);

        //}
        //public string Sender
        //{
        //    get { return sender; }
        //    set => Set(ref sender, value);

        //}
        public List<int> Years { get;} = new List<int>() { DateTime.Now.Year, DateTime.Now.Year-1, DateTime.Now.Year-2 };
        public List<Months> MonthsList { get; } = new List<Months> 
        { Months.Январь, 
            Months.Февраль, 
            Months.Март, 
            Months.Апрель, 
            Months.Май,
            Months.Июнь, 
            Months.Июль, 
            Months.Август, 
            Months.Сентябрь, 
            Months.Октябрь,
            Months.Ноябрь,
            Months.Декабрь
        };
        
        
        public enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }

        private Page currentPage;
        /// <summary>
        /// Текущая страница
        /// </summary>
        public Page CurrentPage 
        {
            get { return currentPage; }
            set => Set(ref currentPage, value);
        }
/// <summary>
/// Страница Мастера запросов
/// </summary>
public Page RequestMasterPage { get; set; }
        public Page MainPage { get; set; }


        #endregion

        #region Команды
        #region Пробная команда
        public ICommand ShowMessageCommand { get; }
        private void OnShowMessageCommandExecuted(object p)
        {
            MessageBox.Show("Hello, World!");
        }
        private bool CanShowMessageCommandExecuted(object p) => true;

        #endregion

        public ICommand ShowAnotherPageCommand { get; }
        private void OnShowAnotherPageExecuted(object p)
        {
            
            CurrentPage = RequestMasterPage;
            
        }
        private bool CanShowAnotherPageExecuted(object p) => true;





        #endregion

        public RequestViewModel()
        {
            RequestMasterPage = new RequestMaster();
            //свойство-объект команды инициализируется, передаются параметры методов(исполняющий метод и разрешающий)
            ShowMessageCommand = new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecuted);
            ShowAnotherPageCommand = new LambdaCommand(OnShowAnotherPageExecuted, CanShowAnotherPageExecuted);
            

        }
    }
}
