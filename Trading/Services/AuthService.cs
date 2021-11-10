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
using Trading.Interfaces;
using Trading.OptionBinders;

namespace Trading.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly AuthOptions _options;

        public AuthService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            
            _options = configuration.GetSection(AuthOptions.JWT).Get<AuthOptions>();
        }

        public async Task<object> GetTokenAsync(string login, string password)
        {
            string passwordHash = Utils.PasswordEncryption.EncryptPassword(password);

            var identity = await GetIdentityAsync(login, passwordHash);

            if (identity == null)
            {
                return null;
            }

            var date = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    notBefore: date,
                    claims: identity.Claims,
                    expires: date.AddDays(_options.Lifetime),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string login, string passwordHash)
        {
            var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == passwordHash); 

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
