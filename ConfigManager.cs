using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RequestManager.Models.Config;

namespace RequestManager
{
    internal class ConfigManager
    {
        public void DeserializeConfig()
        {
            

            Configuration configuration = new Configuration();
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            //Десериализация
            configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filePath));
            Console.WriteLine("Success");
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
