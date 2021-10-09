using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Data.Repository;
using Trading.DTO.Request;
using Trading.Interfaces.Database;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IRepository<User, int> userRepository, IConfiguration configuration)
        {
            _logger = logger;
            _userRepository = userRepository as UserRepository;
            _configuration = configuration;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody]AuthRequestDTO authRequest)
        {
            var identity = await GetIdentity(authRequest.Login, authRequest.Password);

            if (identity == null)
                return BadRequest(new { errorText = "Invalid username or password." });


            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(double.Parse(_configuration["Lifetime"]))),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            var user = await _userRepository.GetByLoginAndPasswordAsync(login, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
