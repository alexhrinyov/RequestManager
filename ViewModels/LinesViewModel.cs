using RequestManager.Data.Entities;
using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.ViewModels
{
    internal class LinesViewModel:ViewModel
    {


        #region Свойства
        private List<Line> lines;
        /// <summary>
        /// Список линий в запросе
        /// </summary>
        public List<Line> Lines
        {
            get { return lines; }
            set => Set(ref lines, value);
        }


        #endregion





        public LinesViewModel()
        {

        }
    }
}
