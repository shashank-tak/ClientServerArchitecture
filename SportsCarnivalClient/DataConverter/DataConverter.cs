using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarnivalClient.DataConverter
{
    class DataConverterClass
    {
        public T DeserializeJsonIntoObjects<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            T returnObject = JsonConvert.DeserializeObject<T>(jsonString);
            return returnObject;
        }
        public String SerializeJsonIntoObjects<T>(string filePath, T jsonObject)
        {
            var jsonOutput = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(jsonOutput));
            return "File saved at " + filePath;
        }
    }
}
