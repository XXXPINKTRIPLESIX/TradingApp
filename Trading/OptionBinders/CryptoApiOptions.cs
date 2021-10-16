using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.OptionBinders
{
    public class CryptoApiOptions
    {
        public static string CryptoApi = "CryptoApi";

        public string BaseUrl { get; set; }
        public string Key { get; set; }
        public string Header { get; set; }
    }
}
