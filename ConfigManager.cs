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
    internal class ConfigManager
    {
        /// <summary>
        /// Десериализация конфигурации из файла jsconfig.json
        /// </summary>
        /// <returns></returns>
        /// 
        private readonly static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "jsconfig.json");
        public static Configuration DeserializeConfig()
        {
            Configuration configuration = new Configuration();
            //Десериализация
            configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filePath));
            return configuration;
            
        }
        /// <summary>
        /// Сериализация конфигурации в файл jsconfig.json
        /// </summary>
        /// <param name="configuration"></param>
        public static void SerializeConfig(Configuration configuration)
        {
            //Сериализация
            string json = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            File.WriteAllText(filePath, json);
            //using (StreamWriter file = new StreamWriter(filePath))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, configuration);
            //}
        }
    }
}
