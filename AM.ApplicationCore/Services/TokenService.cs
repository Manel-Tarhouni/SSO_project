using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AM.ApplicationCore.Services
{
    public class TokenService : ITokenService<Token>
    {
        protected readonly IGenericRepository<Token> _TokenRepository;
        protected readonly IConfiguration _configuration;


        public TokenService(IGenericRepository<Token> TokenRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _TokenRepository = TokenRepository;
        }

        public Task<ClaimsPrincipal> DecodeAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<Token> CreateTokenAsync(User user)
        {
            string secretKey = _configuration["TSettings:Token"]!;
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                    new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                 //   new Claim(JwtRegisteredClaimNames.Email,user.Email),

                ]),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("TSettings:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = _configuration["TSettings: Issuer"],
                Audience = _configuration["TSettings: Audience"]
};
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

        var token1= new Token
        {
            UserId = user.Id,
            TokenValue = token,
            ExpiryDate = tokenDescriptor.Expires ?? DateTime.UtcNow.AddMinutes(30) 
        };
           //await _TokenRepository.AddTokenAsync(token1);

            return Task.FromResult(token1);
        }

        public Task<string> EncodeAsync(Guid userId, string email, TimeSpan expiryDuration)
        {
            throw new NotImplementedException();
        }


        public Task RevokeAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
