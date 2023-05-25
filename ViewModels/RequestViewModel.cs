using RequestManager.Data.Entities;
using RequestManager.Data.Repositories;
using RequestManager.Infrastructure.Commands;
using RequestManager.Models.Config;
using RequestManager.ViewModels.Base;
using RequestManager.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RequestManager.ViewModels
{
    internal class RequestViewModel : ViewModel
    {
        private RequestRepository requestRepository;
        private IEnumerable<Request> requestList;
        /// <summary>
        /// Коллекция запросов
        /// </summary>
        public IEnumerable<Request> Requests
        {
            get { return requestList; }
            set => Set(ref requestList, value);
        }

        #region Свойства

        public List<int> Years { get; } = new List<int>() { DateTime.Now.Year, DateTime.Now.Year - 1, DateTime.Now.Year - 2 };
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


        #region Работа с конфигурацией
        /// <summary>
        /// Объект конфигурации из json
        /// </summary>
        public Configuration ConfigObject { get; set; }

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
        #endregion

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
        
        private Visibility executorColumnVisibility;

        /// <summary>
        /// Отмеченность чекбокса исполнитель
        /// </summary>
        private bool executorChecked = true;
        /// <summary>
        /// CheckBox visibility state for Executor column
        /// </summary>
        public bool ExecutorChecked
        { get => executorChecked;
            set
            {
                Set(ref executorChecked, value);

            }
        }
        #region Свойства RequestMaster
        private string senderNew;
        public string SenderNew
        {
            get => senderNew;
            set => Set(ref senderNew, value);
        }
        private string managerNew;
        public string ManagerNew
        {
            get => managerNew;
            set => Set(ref managerNew, value);
        }
        private string executorNew;
        public string ExecutorNew
        {
            get => executorNew;
            set => Set(ref executorNew, value);
        }

        #endregion

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
        #region Изменение сервера
        public ICommand SaveServer { get; }
        private void OnSaveServerCommandExecuted(object parameter)
        {
            if (ConfigObject.Server != null)
            {
                ConfigManager.SerializeConfig(ConfigObject);
            }

        }
        private bool CanSaveServerExecuted(object p) => true;

        #endregion
        #region Добавить запрос

        public ICommand CreateRequest { get; }
        private void OnAddRequestCommandExecuted(object parameter)
        {
            var year = DateTime.Now.Year.ToString();
            var month = MonthsList[DateTime.Now.Month].ToString();
            var dt = DateTime.Now.ToString();
            string fp = Path.Combine("D:\\Работа\\Запросы", year, month, ManagerNew, dt);
            var request = new Request()
            {
                CreationDate = DateTime.Now,
                Executor = ExecutorNew,
                Sender = SenderNew,
                Manager = ManagerNew,
                UpdateDate = DateTime.Now,
                FolderPath = fp
            };
            requestRepository.Add(request);
            CurrentPage = MainPage;
            Requests = requestRepository.SelectAll();
            
        }
        private bool CanAddRequestCommandExecuted(object p) => true;
        #endregion


        #endregion

        public RequestViewModel()
        {
          
            //свойство-объект команды инициализируется, передаются параметры методов(исполняющий метод и разрешающий)
            ShowMessageCommand = new LambdaCommand(OnShowMessageCommandExecuted, CanShowMessageCommandExecuted);
            ShowAnotherPageCommand = new LambdaCommand(OnShowAnotherPageExecuted, CanShowAnotherPageExecuted);
            DeleteItemCommand = new LambdaCommand(OnDeleteItemCommandExecuted, CanDeleteItemCommandExecuted);
            AddItemCommand = new LambdaCommand(OnAddItemCommandExecuted, CanAddItemCommandExecuted);
            CreateRequest = new LambdaCommand(OnAddRequestCommandExecuted, CanAddRequestCommandExecuted);
            SaveServer = new LambdaCommand(OnSaveServerCommandExecuted, CanSaveServerExecuted);

            //Начальная страница и её контекст данных
            MainPage = new MainPage();
            CurrentPage = MainPage;
            CurrentPage.DataContext = this;
            ConfigObject = ConfigManager.DeserializeConfig();

            //Загрузка запросов из БД при старте
            requestRepository = new RequestRepository( new Data.RequestManagerContext());
            Requests = requestRepository.SelectAll();

        }
        // Методы

    }
}
