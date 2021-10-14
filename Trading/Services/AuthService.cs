using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Trading.Data;
using Trading.Data.Models;
using Trading.DTO.Request;
using Trading.Interfaces;

namespace Trading.Services
{
    public class AuthService : IService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public AuthService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public async Task<object> GetTokenAsync(string login, string password)
        {
            var identity = await GetIdentityAsync(login, password);

            if (identity == null)
                return null;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.AddDays(double.Parse(_configuration["Lifetime"])),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string login, string password)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password); 

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
