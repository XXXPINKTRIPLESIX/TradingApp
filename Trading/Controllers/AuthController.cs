using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.DTO.Request;
using Trading.Interfaces;
using Trading.Services;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AuthService _authService;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator, IService authService)
        {
            _logger = logger;
            _authService = authService as AuthService;
            _mediator = mediator;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody]AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.GetTokenAsync(authDTO.Login, authDTO.Password);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
