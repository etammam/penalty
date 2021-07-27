using System.Collections.Generic;
using Newtonsoft.Json;

namespace Penalty.Integration.Exchange.Models
{
    public class ExchangerateExchangeModel
    {
        public string Result { get; set; }
        public string Documentation { get; set; }
        [JsonProperty("terms_of_use")] 
        public string TermsOfUse { get; set; }
        [JsonProperty("time_zone")] 
        public string TimeZone { get; set; }
        [JsonProperty("time_last_update")] 
        public string TimeLastUpdate { get; set; }
        [JsonProperty("time_next_update")] 
        public string TimeNextUpdate { get; set; }
        [JsonProperty("conversion_rates")] 
        public Dictionary<string, double> ConversionRate { get; set; }
    }
}