using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lern.Core.Configuration;
using Lern.Core.Interfaces;
using Lern.Core.ProjectAggregate.User.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Lern.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IAuthConfiguration _authConfiguration;

        public JwtService(IAuthConfiguration configuration)
        {
            _authConfiguration = configuration;
        }

        public string GetGeneratedJwtToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.PrimarySid, userDto.Id.ToString()),
                    new Claim(ClaimTypes.Email, userDto.Email),
                    new Claim(ClaimTypes.Role, userDto.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _authConfiguration.Issuer,
                Audience = _authConfiguration.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_authConfiguration.Key)
                    ),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}