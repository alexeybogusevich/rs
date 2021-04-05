using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KNU.RS.Logic.Services.JWTGenerator
{
    public class HMACSHA512JWTGenerator : IJWTGenerator
    {
        private readonly SymmetricSecurityKey key;

        public HMACSHA512JWTGenerator(IOptions<TokenConfiguration> options)
        {
            key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.Key));
        }

        public string CreateToken(User user, IEnumerable<string> roles)
        {
            var claims = GetClaims(user.Id, roles);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static Claim[] GetClaims(Guid id, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, id.ToString())
            };

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims.ToArray();
        }
    }
}
