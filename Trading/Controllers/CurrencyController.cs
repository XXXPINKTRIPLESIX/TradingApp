using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
using Trading.Common;
using Trading.Data.Models;
using Trading.DTO.Crypro;
using Trading.DTO.Fiat;
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
        [ProducesResponseType(typeof(List<Account>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetCurrenciesQuery());

            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            
            return StatusCode(code, res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Currency), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetCurrencyQuery query)
        {
            var res = await _mediator.Send(query);
            
            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;
            
            return StatusCode(code, res);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Currency), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] DeleteCurrencyCommand command)
        {
            var res = await _mediator.Send(command);
            
            var code = res != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound;

            return StatusCode(code, res);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCurrencyCommand createCommand)
        {
            var res = await _mediator.Send(createCommand);
            
            var code = res ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            return StatusCode(code);
        }

        [HttpPost]
        [Route("fiat/exchange")]
        [ProducesResponseType(typeof(ExecutionResult<FiatResponseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<FiatResponseDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FiatExchange([FromBody] ExchangeFiatCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            return res.IsSuccess 
                ? StatusCode(StatusCodes.Status200OK, res.Result) 
                : StatusCode(StatusCodes.Status400BadRequest, res.Error);
        }

        [HttpGet]
        [Route("fiat/rates")]
        [ProducesResponseType(typeof(ExecutionResult<FiatResponseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<FiatResponseDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FiatCurrencyRates([FromQuery] GetRatesFiatCurrencyQuery query)
        {
            var res = await _mediator.Send(query);

            return res.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, res.Result)
                : StatusCode(StatusCodes.Status400BadRequest, res.Error);
        }

        [HttpPost]
        [Route("crypto/exchange")]
        [ProducesResponseType(typeof(ExecutionResult<CryptoResponseDTO>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<CryptoResponseDTO>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CryptoExchange([FromBody] ExchangeCryptoCurrencyCommand command)
        {
            var res = await _mediator.Send(command);

            return res.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, res.Result)
                : StatusCode(StatusCodes.Status400BadRequest, res.Error);
        }

        [HttpGet]
        [Route("crypto/rates")]
        [ProducesResponseType(typeof(ExecutionResult<List<CryptoResponseDTO>>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExecutionResult<List<CryptoResponseDTO>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CryptoCurrencyRates([FromQuery] GetRatesCryptoCurrencyQuery query)
        {
            var res = await _mediator.Send(query);

            var code = res.IsSuccess ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;

            return res.IsSuccess
                ? StatusCode(StatusCodes.Status200OK, res.Result)
                : StatusCode(StatusCodes.Status400BadRequest, res.Error);
        }
    }
}
