using FluentResults;
using HotelTravelMemories.Auth.Data.Request;
using HotelTravelMemories.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogarUsuario(LoginRequest request)
        {
            Result result = _loginService.LogarUsuario(request);

            if (result.IsFailed) 
                return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }
    }
}
