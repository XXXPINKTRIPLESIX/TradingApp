using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
using Trading.Data.Models;
using Trading.DTO.Request;
using Trading.Queries.CurrencyQueries;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IMediator _mediator;

        public CurrencyController(ILogger<CurrencyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetCurrenciesQuery());

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new GetCurrencyQuery(id));

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new DeleteCurrencyCommand(id));

            if (!res)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new CreateCurrencyCommand(currency));

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new UpdateCurrencyCommand(currency));

            if (!res)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        [Route("Exchange")]
        public async Task<IActionResult> Exchange([FromBody] FiatRequestExchangeDTO exchangeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new ExchangeCurrencyCommand(exchangeDTO));

            if (res.SuccessResponse == null)
                return BadRequest(res.ErrorResponse);                    
            return Ok(res.SuccessResponse);                
        }

        [HttpPost]
        [Route("Rate")]
        public async Task<IActionResult> CurrencyRate([FromQuery] string baseCurrency)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new RateCurrencyCommand(baseCurrency));

            if (res.SuccessResponse == null)
                return BadRequest(res.ErrorResponse);
            return Ok(res.SuccessResponse);
        }
    }
}
