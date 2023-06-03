using RequestManager.Data.Entities;
using RequestManager.Data.Repositories;
using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        private object selectedRatedCurrent;
        public object SelectedRatedCurrent
        {
            get => selectedRatedCurrent;
            set
            {
                Set(ref selectedRatedCurrent, value);
            }


        }


        #endregion





        public LinesViewModel()
        {
            
        }
    }
}
