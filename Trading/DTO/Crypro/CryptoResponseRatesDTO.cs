using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Crypro
{
    public class CryptoResponseRatesDTO
    {
        [JsonProperty("asset_id_base")]
        public string AssetIdBase { get; set; }

        [JsonProperty("rates")]
        public List<Rates> Rates { get; set; }
    }

    public class Rates
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("asset_id_quote")]
        public string AssetIdQuote { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }
    }
}
