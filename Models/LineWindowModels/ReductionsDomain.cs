using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Data.Entities
{
    internal class ReductionsDomain: ViewModels.Base.ViewModel
    {
        public int Id { get; set; }
        public int LinePropertiesId { get; set; }
        public int FirstCurrent { get; set; }
        public int SecondCurrent { get; set; }
    }
}
