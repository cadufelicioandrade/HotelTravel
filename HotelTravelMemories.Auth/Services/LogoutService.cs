﻿using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Deslogar()
        {
            var resulIdentity = _signInManager.SignOutAsync();

            if (resulIdentity.IsCompletedSuccessfully)
                return Result.Ok();

            return Result.Fail("Logout falhou :(");
        }
    }
}
