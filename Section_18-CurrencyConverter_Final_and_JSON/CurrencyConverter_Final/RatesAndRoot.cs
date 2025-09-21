using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter_Final
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Rates
    {
        [JsonProperty("INR")]
        public double INR { get; set; }

        [JsonProperty("USD")]
        public double USD { get; set; }

        [JsonProperty("EUR")]
        public double EUR { get; set; }

        [JsonProperty("SAR")]
        public double SAR { get; set; }

        [JsonProperty("RON")]
        public double RON { get; set; }

        [JsonProperty("MDL")]
        public double MDL { get; set; }

        [JsonProperty("RUB")]
        public double RUB { get; set; }

        [JsonProperty("GBP")]
        public double GBP { get; set; }

        [JsonProperty("CNY")]
        public double CNY { get; set; }
    }

    public class Root
    {
        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }
    }


}
