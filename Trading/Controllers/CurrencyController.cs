using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Interfaces.Database;
using Trading.Interfaces.Services;
using Trading.DTO.Fiat;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly ICurrencyService _currencyService;
        private readonly IRepository<Currency, int> _currencyRepository;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService, IRepository<Currency, int> currencyRepository)
        {
            _logger = logger;
            _currencyService = currencyService;
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var currencies = await _currencyRepository.GetAsync();

            if (currencies == null)
                return NotFound();

            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public async Task<Currency> Get(int id) { return await _currencyRepository.GetAsync(id); }

        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id) 
        {
            await _currencyRepository.DeleteAsync(id);
            return new StatusCodeResult(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> Add(Currency currency)
        {
            await _currencyRepository.AddAsync(currency);
            return new StatusCodeResult(200);
        }

        [HttpPatch]
        public async Task<StatusCodeResult> Update(Currency currency) 
        {
            await _currencyRepository.UpdateAsync(currency);
            return new StatusCodeResult(200);
        }

        [HttpGet("{baseCurrency}/{subCurrency}/{amount}")]
        public async Task<FiatExchangeDTO> Exchange(string baseCurrency, string subCurrency, double amount) 
        { 
            return await _currencyService.Exchange(baseCurrency, subCurrency, amount); 
        }

        [HttpGet("{baseCurrency}")]
        public async Task<FiatRateDTO> CurrencyRate(string baseCurrency) 
        {
            return await _currencyService.Rates(baseCurrency);
        }
    }
}
