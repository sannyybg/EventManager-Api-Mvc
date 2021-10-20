using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Abstractions;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;
        private readonly int _expDate;

        public JWTService(IOptions<JWTConfiguration> option)
        {
            _secret = option.Value.Secret;
            _expDate = option.Value.ExpirationInMinutes;
        }



        public string GenerateSecurityToken(bool isAdmin, int id)
        {
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);

                var tokenDescriptor = new SecurityTokenDescriptor();
                
                if (isAdmin)
                {
                    tokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "Admin") });
                }
                else
                {
                    tokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, "User"), new Claim("id", id.ToString()) });
                }
                tokenDescriptor.Expires = DateTime.Now.AddMinutes(_expDate);
                tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);


                var token = tokenHandler.CreateToken(tokenDescriptor);
                
                var tk = tokenHandler.WriteToken(token);
                return tk;

                
            }
        }
    }
}
