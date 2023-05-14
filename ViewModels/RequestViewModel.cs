using RequestManager.Infrastructure.Commands;
using RequestManager.Models.Config;
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


        
        /// <summary>
        /// Объект конфигурации из json
        /// </summary>
        public Configuration ConfigObject{get; set; }

        

        private string selectedManager;
        /// <summary>
        /// Выбранный в Listbox менеджер
        /// </summary>
        public string SelectedManager
        {
            get { return selectedManager; }
            set => Set(ref selectedManager, value);
        }
        private string selectedExecutor;
        /// <summary>
        /// Выбранный в Listbox исполнитель
        /// </summary>
        public string SelectedExecutor
        {
            get { return selectedExecutor; }
            set => Set(ref selectedExecutor, value);
        }
        private string? newManager;
        /// <summary>
        /// Новый менеджер
        /// </summary>
        public string? NewManager
        {
            get => newManager;
            set => Set(ref newManager, value);
        }

        private string? newExecutor;
        /// <summary>
        /// Новый исполнитель
        /// </summary>
        public string? NewExecutor
        {
            get => newExecutor;
            set => Set(ref newExecutor, value);
        }
        private Visibility executorColumnVisibility;
        /// <summary>
        /// Видимость колонки с исполнителями в главном окне
        /// </summary>
        public Visibility ExecutorColumnVisibility
        {
            get => executorColumnVisibility;
            set => Set(ref executorColumnVisibility, value);
        }

        private bool executorChecked = true;
        /// <summary>
        /// CheckBox visibility state for Executor column
        /// </summary>
        public bool ExecutorChecked 
        {   get => executorChecked;
            set
            {
                Set(ref executorChecked, value);
                ChangeExecutorVisibilityCommand.Execute(null);
            }
        }


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
        #region Создание нового расчёта
        /// <summary>
        /// Переход на следующую страницу создания запроса
        /// </summary>
        public ICommand ShowAnotherPageCommand { get; }
        private void OnShowAnotherPageExecuted(object p)
        {
           // Меняем текущую страницу и устанавливаем ей текущий контекст viewModel
            CurrentPage = new RequestMaster();
            CurrentPage.DataContext = this;
   
        }
        private bool CanShowAnotherPageExecuted(object p) => true;

        #endregion
        #region Удаление менеджера/исполнителя
        public ICommand DeleteItemCommand { get; }
        private void OnDeleteItemCommandExecuted(object parameter)
        {
            switch (parameter)
            {
                case "manager":
                    if (SelectedManager != null)
                    {
                        ConfigObject.Managers = ConfigObject.Managers.Where(m => m != SelectedManager).ToList();
                        ConfigManager.SerializeConfig(ConfigObject);
                    }
                    break;
                case "executor":
                    if (SelectedExecutor != null)
                    {
                        ConfigObject.Executors = ConfigObject.Executors.Where(m => m != SelectedExecutor).ToList();
                        ConfigManager.SerializeConfig(ConfigObject);
                    }
                    break;
            }
            
            
        }
        private bool CanDeleteItemCommandExecuted(object p) => true;

        #endregion
        #region Добавление менеджера/исполнителя
        public ICommand AddItemCommand { get; }
        private void OnAddItemCommandExecuted(object parameter)
        {
            switch (parameter)
            {
                case "manager":
                    if (NewManager != null)
                    {
                        ConfigObject.Managers = ConfigObject.Managers.Append(NewManager).ToList();
                        ConfigManager.SerializeConfig(ConfigObject);
                        NewManager = null;
                    }
                    break;
                case "executor":
                    if (NewExecutor != null)
                    {
                        ConfigObject.Executors = ConfigObject.Executors.Append(NewExecutor).ToList();
                        ConfigManager.SerializeConfig(ConfigObject);
                        NewExecutor = null;
                    }
                    break;
            }
              
        }
        private bool CanAddItemCommandExecuted(object p) => true;

        #endregion
        #region Скрытие колонки исполнителя
        public ICommand ChangeExecutorVisibilityCommand { get; }
        private void OnChangeExecutorVisibilityCommandExecuted(object p)
        {
            if(ExecutorColumnVisibility == Visibility.Hidden)
                ExecutorColumnVisibility = Visibility.Visible;
            else
                ExecutorColumnVisibility = Visibility.Hidden;
        }
        private bool CanChangeExecutorVisibilityExecuted(object p) => true;

        #endregion


        #endregion

        public RequestViewModel()
        {
          
            //свойство-объект команды инициализируется, передаются параметры методов(исполняющий метод и разрешающий)
            ShowMessageCommand = new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecuted);
            ShowAnotherPageCommand = new LambdaCommand(OnShowAnotherPageExecuted, CanShowAnotherPageExecuted);
            DeleteItemCommand = new LambdaCommand(OnDeleteItemCommandExecuted, CanDeleteItemCommandExecuted);
            AddItemCommand = new LambdaCommand(OnAddItemCommandExecuted, CanAddItemCommandExecuted);
            ChangeExecutorVisibilityCommand = new LambdaCommand(OnChangeExecutorVisibilityCommandExecuted, CanDeleteItemCommandExecuted);
            //Начальная страница и её контекст данных
            CurrentPage = new MainPage();
            CurrentPage.DataContext = this;
            ConfigObject = ConfigManager.DeserializeConfig();
            

        }
    }
}
