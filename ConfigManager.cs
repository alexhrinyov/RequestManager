using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RequestManager.Models.Config;
using RequestManager.ViewModels.Base;

namespace RequestManager
{
    internal class ConfigManager:ViewModel
    {
        public static Configuration DeserializeConfig()
        {
            Configuration configuration = new Configuration();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            //Десериализация
            configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filePath));
            return configuration;
            //Сериализация
            //string json = JsonConvert.SerializeObject(points, Formatting.Indented);
            //File.WriteAllText(filePath, json);
            //using (StreamWriter file = new StreamWriter(filePath))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, points);
            //}
        }
    }
}
