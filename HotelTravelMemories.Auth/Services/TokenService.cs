using HotelTravelMemories.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Services
{
    public class TokenService
    {
        public TokenService()
        {
        }

        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("893906d9d8fdcc738761f5d356870ad62480f2db"));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenStr);
        }
    }
}
