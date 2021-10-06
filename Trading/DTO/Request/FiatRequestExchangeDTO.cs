using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Request
{
    public class FiatRequestExchangeDTO
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Amount { get; set; }
    }
}
