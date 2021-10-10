using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository;
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
        private readonly UserRepository _userRepository;

        public AuthController(ILogger<AuthController> logger, IRepository<User, int> userRepository, IService authService)
        {
            _logger = logger;
            _authService = authService as AuthService;
            _userRepository = userRepository as UserRepository;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody]AuthRequestDTO authRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.GetTokenAsync(authRequest);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
