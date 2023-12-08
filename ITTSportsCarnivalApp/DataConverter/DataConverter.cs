using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp.DataConverter
{
    public class DataConverterClass
    {
        public T DeserializeJsonIntoObjects<T>(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                T returnObject = JsonConvert.DeserializeObject<T>(jsonString);
                return returnObject;
            }
            catch(Exception ex)
            {
                Object obj = ApplicationConstants.DeserializeJsonIntoObjectsFailureMessage;
                return (T) Convert.ChangeType(obj, typeof(T));
            }
            
        }
        public String SerializeJsonIntoObjects<T>(string filePath, T jsonObject)
        {
            try
            {
                var jsonOutput = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(filePath, jsonOutput);
                return filePath;
            }
            catch(Exception ex)
            {
                return ApplicationConstants.SerializeJsonIntoObjectsFailureMessage;
            }
            
        }
    }
}
