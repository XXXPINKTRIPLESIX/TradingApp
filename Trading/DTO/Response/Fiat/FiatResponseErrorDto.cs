using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Response.Fiat
{
    public class FiatResponseErrorDto
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("error-type")]
        public string ErrorType { get; set; }
    }
}
