using EzBudget.Data.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EzBudget.Data.Readers
{
    public class JsonReader : IJsonReader
    {
        private readonly DataAccessConfig dataAccessConfig;

        public JsonReader(DataAccessConfig dataAccessConfig)
        {
            this.dataAccessConfig = dataAccessConfig;
        }

        public T ReadData<T>(string filePath, string fileName)
        {
            var fullFilePath = Path.Combine(this.dataAccessConfig.BasePath, filePath, fileName);
            
            if (!File.Exists(fullFilePath)) throw new FileNotFoundException();

            using (StreamReader streaReader = new StreamReader(fullFilePath))
            {
                string json = streaReader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
        }
    }
}
