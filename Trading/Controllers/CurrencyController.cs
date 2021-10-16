using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
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
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetCurrencyQuery query)
        {
            var res = await _mediator.Send(query);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyCommand createCommand)
        {
            await _mediator.Send(createCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("fiat/exchange")]
        public async Task<IActionResult> FiatExchange([FromBody] ExchangeFiatCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            if (res.SuccessResponse == null)
            {
                return BadRequest(res.ErrorResponse);
            }

            return Ok(res.SuccessResponse);
        }

        [HttpGet]
        [Route("fiat/rates")]
        public async Task<IActionResult> FiatCurrencyRates([FromQuery] GetRatesFiatCurrencyQuery query)
        {
            var res = await _mediator.Send(query);

            if (res.SuccessResponse == null)
            {
                return BadRequest(res.ErrorResponse);
            }

            return Ok(res.SuccessResponse);
        }

        [HttpPost]
        [Route("crypto/exchange")]
        public async Task<IActionResult> CryptoExchange([FromBody] ExchangeCryptoCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpGet]
        [Route("crypto/rates")]
        public async Task<IActionResult> CryptoCurrencyRates([FromQuery] GetRatesCryptoCurrencyQuery query)
        {
            var res = await _mediator.Send(query);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }
    }
}
