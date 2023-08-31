using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Data.Entities
{
    internal class ReductionsDomain: ViewModels.Base.ViewModel
    {
        private int id;
        private LinePropertiesDomain lineProperties;
        private int firstCurrent;
        private int secondCurrent;
        private int quantity;
        public int Id {
            get { return id; }
        }
        public LinePropertiesDomain LineProperties {
            get { return lineProperties; }
            set => Set(ref lineProperties, value);
        }
        public int FirstCurrent {
            get { return firstCurrent; }
            set => Set(ref firstCurrent, value);
        }
        public int SecondCurrent {
            get { return secondCurrent; }
            set => Set(ref secondCurrent, value);
        }
        public int Quantity
        {
            get { return quantity; }
            set => Set(ref quantity, value);
        }

    }
}
