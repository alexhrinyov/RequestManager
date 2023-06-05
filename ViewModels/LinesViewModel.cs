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

        private int requestId;
        public int RequestId
        {
            get => requestId;
            set => Set(ref requestId, value);
        }

        



        #endregion

        #region Команды
        public ICommand PushRequestDataCommand { get; }

        private async void OnPushRequestDataCommand(object parameter)
        {
            foreach (var line in Lines)
            {
                if (line != null)
                {
                    line.RequestId = RequestId;
                }    
            }
            try
            {
                bool updatedOnly = true;
                foreach (Line line in Lines)
                {
                    
                    if (line.Id == 0)
                    {
                        updatedOnly = false;
                        await requestRepository.AddSingleLineAsync(line);
                    }
                    else
                    {

                       await requestRepository.UpdateLineAsync(line);
                       
                    }
                }
                if (updatedOnly)
                {
                    MessageBox.Show("Обновлено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Изменения отправлены в базу данных", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private bool CanPushRequestDataExecuted(object p) => true;
        #endregion





        public LinesViewModel()
        {
            
            requestRepository = new RequestRepository(new Data.RequestManagerContext());
            PushRequestDataCommand = new LambdaCommand(OnPushRequestDataCommand, CanPushRequestDataExecuted);
        }
    }
}
