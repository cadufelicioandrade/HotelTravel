using FluentResults;
using HotelTravelMemories.Auth.Data.Request;
using HotelTravelMemories.Auth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogarUsuario(LoginRequest request)
        {
            var resultIdentity = _signInManager
                                    .PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultIdentity.Result.Succeeded)
            {
                IdentityUser<int> userIdentity = _signInManager
                                .UserManager.Users
                                .FirstOrDefault(u => u.NormalizedUserName.Equals(request.Username.ToUpper()));

                Token token = _tokenService.CreateToken(userIdentity);

                return Result.Ok().WithSuccess(token.Valor);
            }

            return Result.Fail("Login falhou.");
        }
    }
}
