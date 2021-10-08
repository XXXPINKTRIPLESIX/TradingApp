using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Exceptions
{
    public class TradingApiBaseException : Exception
    {
        public TradingApiBaseException(string message) : base(message) { }
    }
}
