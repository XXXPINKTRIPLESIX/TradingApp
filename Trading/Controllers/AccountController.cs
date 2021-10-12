using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.AccountCommands;
using Trading.Data.Models;
using Trading.Queries.AccountQueries;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase  
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var res = await _mediator.Send(new GetAccountsQuery());

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _mediator.Send(new GetAccountQuery(id));

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Account account) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _mediator.Send(new CreateAccountCommand(account));

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]Account account) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _mediator.Send(new UpdateAccountCommand(account));

            if (!res)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _mediator.Send(new DeleteAccountCommand(id));

            if (!res)
                return NotFound();
            return Ok(res);
        }
    }
}
