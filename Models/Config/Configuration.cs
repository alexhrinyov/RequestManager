using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Models.Config
{
    public class Configuration
    {
        public List<string> Managers { get; set; }
        public List<string> Executors { get; set; }
        public Fonts Fonts { get; set; }

        public Configuration()
        {
            Configuration configuration = ConfigManager.DeserializeConfig();
            this.Managers = configuration.Managers;
        }

    }
}
