using Newtonsoft.Json;
using RequestManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RequestManager.Models.Config
{
    internal class Configuration:ViewModel
    {

        private string server;
        private List<string> managers;
        private List<string> executors;
        private Fonts fonts;
        
        public string Server
        {
            get { return server; }
            set => Set(ref server, value);
        }
        public List<string> Managers { 
            get { return managers; }
            set => Set(ref managers, value);
        }
        public List<string> Executors
        {
            get { return executors; }
            set => Set(ref executors, value);
        }
        
        public Fonts Fonts { get; set; }

        public Configuration()
        {
           
        }
        

    }
}
