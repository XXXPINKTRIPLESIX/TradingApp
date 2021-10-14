using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.DTO.Request
{
    public class CreateCurrencyDTO
    {
        public string CurrencyCode { get; set; }
        public CurrencyType Type { get; set; }
    }
}
