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
        [Route("Exchange")]
        public async Task<IActionResult> Exchange([FromBody] ExchangeCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            if (res.SuccessResponse == null)
            {
                return BadRequest(res.ErrorResponse);
            }

            return Ok(res.SuccessResponse);
        }

        [HttpPost]
        [Route("Rate")]
        public async Task<IActionResult> CurrencyRate([FromQuery] RateCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            if (res.SuccessResponse == null)
            {
                return BadRequest(res.ErrorResponse);
            }

            return Ok(res.SuccessResponse);
        }
    }
}
