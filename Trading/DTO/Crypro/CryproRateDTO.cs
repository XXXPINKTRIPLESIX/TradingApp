using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Crypro
{
    public class CryproRateDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("year_established")]
        public int? YearEstablished { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("has_trading_incentive")]
        public bool? HasTradingIncentive { get; set; }

        [JsonProperty("trust_score")]
        public int TrustScore { get; set; }

        [JsonProperty("trust_score_rank")]
        public int TrustScoreRank { get; set; }

        [JsonProperty("trade_volume_24h_btc")]
        public double TradeVolume24hBtc { get; set; }

        [JsonProperty("trade_volume_24h_btc_normalized")]
        public double TradeVolume24hBtcNormalized { get; set; }
    }
}
