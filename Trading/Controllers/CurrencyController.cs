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
        public async Task<IActionResult> Get([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _currencyRepository.GetAsync(id);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _currencyRepository.DeleteAsync(id);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _currencyRepository.AddAsync(currency);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(Currency currency) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _currencyRepository.UpdateAsync(currency);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpGet("{baseCurrency}/{subCurrency}/{amount}")]
        public async Task<IActionResult> Exchange([FromRoute] string baseCurrency, [FromRoute]string subCurrency, [FromRoute] double amount) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _currencyService.Exchange(baseCurrency, subCurrency, amount);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpGet("{baseCurrency}")]
        public async Task<IActionResult> CurrencyRate([FromRoute] string baseCurrency) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _currencyService.Rates(baseCurrency);

            if (res == null)
                return NotFound();

            return Ok(res);
        }
    }
}
