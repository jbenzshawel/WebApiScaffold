using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiScaffold.Core.Settings;

namespace WebApiScaffold.Core.Services.Security
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings) 
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(IEnumerable<Claim> claims) 
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenLifeInMinutes),
                Issuer = _jwtSettings.TokenIssuer,
                IssuedAt = DateTime.UtcNow,
                Audience = _jwtSettings.TokenAudience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}