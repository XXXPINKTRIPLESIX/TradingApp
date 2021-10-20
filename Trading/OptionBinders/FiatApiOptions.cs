using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.OptionBinders
{
    public class FiatApiOptions
    {
        public const string FiatApi = "FiatApi";

        public string Key { get; set; }
        public string BaseUrl { get; set; }
    }
}
