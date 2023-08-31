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
        private int id;
        private LinePropertiesDomain lineProperties;
        private int ratedCurrent;
        private int? cBRatedCurrent;
        private int quantity;
        public int Id {
            get { return id; }
       
        }
        public LinePropertiesDomain LineProperties
        {
            get { return lineProperties; }
            set => Set(ref lineProperties, value);
        }
        public int RatedCurrent {
            get { return ratedCurrent; }
            set => Set(ref ratedCurrent, value);
        }
        public int? CBRatedCurrent {
            get { return cBRatedCurrent; }
            set => Set(ref cBRatedCurrent, value);
        }
        public int Quantity {
            get { return quantity; }
            set => Set(ref quantity, value);
        }

    }
}
