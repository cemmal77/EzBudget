using EzBudget.Data.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace EzBudget.Data.Writers
{
    public class JsonWriter : IJsonWriter
    {
        private readonly DataAccessConfig dataAccessConfig;

        public JsonWriter(DataAccessConfig dataAccessConfig)
        {
            this.dataAccessConfig = dataAccessConfig;
        }

        public void WriteData<T>(string filePath, string fileName, T data)
        {
            var path = Path.Combine(this.dataAccessConfig.BasePath, filePath);
            string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            Directory.CreateDirectory(path);
            File.WriteAllText(Path.Combine(path, fileName), json);
        }
    }
}
