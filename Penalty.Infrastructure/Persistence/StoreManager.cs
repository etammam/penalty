using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Penalty.Infrastructure.Persistence
{
    public class StoreManager : IStore
    {
        private readonly ILogger _logger;

        public StoreManager(ILogger logger)
        {
            _logger = logger;
        }

        public object Read<T>(string dataSetName)
        {
            var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/datasets/{dataSetName}");
            var content = File.ReadAllText(location);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public bool SaveChanges(object model, string dataSetName)
        {
            try
            {
                var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/datasets/{dataSetName}");
                var stringfiy = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    var json = new UTF8Encoding(true).GetBytes(stringfiy);
                    stream.Write(json, 0, json.Length);
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e,"Store Manager");
                return false;
            }
        }
    }
}
