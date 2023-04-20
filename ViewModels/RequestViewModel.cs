using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.ViewModels
{
    internal class RequestViewModel: ViewModel
    {
        private int id;
        private string date;
        private string sender;
        public int Id { get { return id; } }
        public string Date 
        {
            get { return date; }
            set => Set(ref date, value);
        
        }
        public string Sender
        {
            get { return sender; }
            set => Set(ref sender, value);

        }

    }
}
