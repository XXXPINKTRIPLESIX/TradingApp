using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Fiat.DTO
{
    public class ErrorResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("error-type")]
        public string ErrorType { get; set; }
    }
}
