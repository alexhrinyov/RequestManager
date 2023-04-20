using RequestManager.Infrastructure.Commands;
using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestManager.ViewModels
{
    internal class RequestViewModel: ViewModel
    {
        #region Примеры свойств
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





        #endregion

        public RequestViewModel()
        {
            //свойство-объект команды инициализируется, передаются параметры методов(исполняющий метод и разрешающий)
            ShowMessageCommand = new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecuted);
        }
    }
}
