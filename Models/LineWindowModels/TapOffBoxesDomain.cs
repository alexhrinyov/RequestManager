using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Data.Entities
{
    internal class TapOffBoxesDomain : ViewModels.Base.ViewModel
    {
        public int Id { get; set; }
        public int LinePropertiesId { get; set; }
        public int RatedCurrent { get; set; }
        public int? CBRatedCurrent { get; set; }
        public int Quantity { get; set; }

    }
}
