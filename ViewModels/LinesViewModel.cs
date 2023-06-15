using AutoMapper;
using RequestManager.Data.Entities;
using RequestManager.Data.Repositories;
using RequestManager.Infrastructure.Commands;
using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestManager.ViewModels
{
    internal class LinesViewModel:ViewModel
    {


        #region Свойства

        private RequestRepository requestRepository;

        private IEnumerable<Line> lines;
        /// <summary>
        /// Список линий в запросе
        /// </summary>
        public IEnumerable<Line> Lines
        {
            get { return lines; }
            set => Set(ref lines, value);
        }

        private IEnumerable<LineDomain> linesDomain;
        /// <summary>
        /// Список линий в запросе
        /// </summary>
        public IEnumerable<LineDomain> LinesDomain
        {
            get { return linesDomain; }
            set => Set(ref linesDomain, value);
        }

        private Line selectedLine;
        public Line SelectedLine
        {
            get => selectedLine;
            set
            {
                Set(ref selectedLine, value);
            }

        }
        private LineDomain selectedLineDomain;
        public LineDomain SelectedLineDomain
        {
            get => selectedLineDomain;
            set
            {
                Set(ref selectedLineDomain, value);
                if (SelectedLineDomain?.Properties == null)
                {
                    SelectedLineDomain.Properties = new List<LinePropertiesDomain>() { new LinePropertiesDomain { OrderNumber=1} };
                }
                
            }

        }
        public IMapper Mapper { get; set; }


        private int requestId;
        public int RequestId
        {
            get => requestId;
            set => Set(ref requestId, value);
        }

        #region Видимость колонок
        private Visibility terminalHeadersSwgVisibility;

        /// <summary>
        /// Отмеченность чекбокса Тщ    
        /// </summary>
        private bool terminalHeadersSwgChecked = true;

        /// <summary>
        /// 
        /// </summary>
        public bool TerminalHeadersSwgChecked
        {
            get => terminalHeadersSwgChecked;
            set
            {
                Set(ref terminalHeadersSwgChecked, value);

            }
        }

        private Visibility terminalHeadersTRVisibility;

        /// <summary>
        /// Отмеченность чекбокса Ттр
        /// </summary>
        private bool terminalHeadersTRChecked = true;
        /// <summary>
        /// Отмеченность чекбокса Ттр
        /// </summary>
        public bool TerminalHeadersTRChecked
        {
            get => terminalHeadersTRChecked;
            set
            {
                Set(ref terminalHeadersTRChecked, value);

            }
        }

        private Visibility TVisibility;

        /// <summary>
        /// Отмеченность чекбокса Т
        /// </summary>
        private bool tChecked = true;
        /// <summary>
        /// Отмеченность чекбокса Т
        /// </summary>
        public bool TChecked
        {
            get => tChecked;
            set
            {
                Set(ref tChecked, value);

            }
        }

        private Visibility FBVisibility;

        /// <summary>
        /// Отмеченность чекбокса Пож. барьеров
        /// </summary>
        private bool fbChecked = true;
        /// <summary>
        /// Отмеченность Пож. барьеров
        /// </summary>
        public bool FbChecked
        {
            get => fbChecked;
            set
            {
                Set(ref fbChecked, value);

            }
        }

        private Visibility capsVisibility;

        /// <summary>
        /// Отмеченность чекбокса заглушек
        /// </summary>
        private bool capsChecked = true;
        /// <summary>
        /// Отмеченность заглушек
        /// </summary>
        public bool CapsChecked
        {
            get => capsChecked;
            set
            {
                Set(ref capsChecked, value);

            }
        }

        private Visibility expVisibility;

        /// <summary>
        /// Отмеченность чекбокса компенсаторов
        /// </summary>
        private bool expChecked = true;
        /// <summary>
        /// Отмеченность компенсаторов
        /// </summary>
        public bool ExpChecked
        {
            get => expChecked;
            set
            {
                Set(ref expChecked, value);

            }
        }

        private Visibility cabelBoxesVisibility;

        /// <summary>
        /// Отмеченность чекбокса кабельных коробок
        /// </summary>
        private bool cabelBoxesChecked = true;
        /// <summary>
        /// Отмеченность кабельных коробок
        /// </summary>
        public bool CabelBoxesChecked
        {
            get => cabelBoxesChecked;
            set
            {
                Set(ref cabelBoxesChecked, value);

            }
        }


        #endregion



        #endregion

        #region Команды
        /// <summary>
        /// Обновление базы данных, загрузка всего
        /// </summary>
        public ICommand PushRequestDataCommand { get; }

        private async void OnPushRequestDataCommand(object parameter)
        {
            
            foreach (LineDomain line in LinesDomain)
            {
                if (line.Id == 0)
                {
                    line.RequestId = RequestId;
                    foreach (LinePropertiesDomain lpd in line.Properties)
                    {
                        if (lpd.Id == 0)
                        {
                            lpd.LineId = line.Id;
                        }
                    }
                }
            }
           
            
        }

        private bool CanPushRequestDataExecuted(object p) => true;
        #endregion

        //public ICommand PropFocusLostCommand { get; }
        //private async void OnPropFocusLostCommand(object parameter)
        //{
        //    MessageBox.Show("Hello");
        //}

        //private bool CanPropFocusLostCommandExecuted(object p) => true;



        public LinesViewModel()
        {
            
            requestRepository = new RequestRepository(new Data.RequestManagerContext());
            PushRequestDataCommand = new LambdaCommand(OnPushRequestDataCommand, CanPushRequestDataExecuted);
            
            
        }
    }
}
