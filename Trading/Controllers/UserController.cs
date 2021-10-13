using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;
using Trading.Data.Models;
using Trading.Interfaces;
using Trading.Queries.UserQueries;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var res = await _mediator.Send(new GetUsersQuery());

            if (res == null)
                return NotFound();
            return Ok(res);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new GetUserQuery(id));

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new DeleteUserCommand(id));

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new CreateUserCommand(user));

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]User user) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _mediator.Send(new UpdateUserCommand(user));

            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
