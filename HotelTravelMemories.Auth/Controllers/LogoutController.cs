using FluentResults;
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
    public class LogoutController : ControllerBase
    {
        private LogoutService _logouService;

        public LogoutController(LogoutService logouService)
        {
            _logouService = logouService;
        }

        [HttpPost]
        public IActionResult DeslogarUsuario()
        {
            Result result = _logouService.Deslogar();

            if (result.IsFailed)
                return Unauthorized(result.Errors);

            return NoContent();
        }

    }
}
