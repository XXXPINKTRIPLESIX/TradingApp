using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.OptionBinders
{
    public class AuthOptions
    {
        public static string JWT = "JWT";
        
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Lifetime { get; set; }
    }
}
