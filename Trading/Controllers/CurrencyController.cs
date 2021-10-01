using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Interfaces.Services;
using Trading.ResponseModels;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet("{baseCurrency}/{subCurrency}/{amount}")]
        public async Task<ExchangeResponse> Exchange(string baseCurrency, string subCurrency, double amount) 
        { 
            return await _currencyService.Exchange(baseCurrency, subCurrency, amount); 
        }
        [HttpGet("{baseCurrency}")]
        public async Task<RatesResponse> CurrenctRate(string baseCurrency) 
        {
            return await _currencyService.Rates(baseCurrency);
        }
    }
}
