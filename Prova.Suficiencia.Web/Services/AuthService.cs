using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Prova.Suficiencia.Web.Services
{
    public class AuthService : IAuthService
    {
        public (string, DateTime) GerarJwtAuth()
        {
            var expiration = DateTime.UtcNow.AddHours(1);

            var secret = Environment.GetEnvironmentVariable("AUTH_JWT_SECRET") ?? "segredoMuitoSecreto";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: null,
                expires: expiration,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}