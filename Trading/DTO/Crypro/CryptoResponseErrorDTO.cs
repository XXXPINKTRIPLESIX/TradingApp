using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Crypro
{
    public class CryptoResponseErrorDTO
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
