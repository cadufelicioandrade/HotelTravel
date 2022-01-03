using FluentResults;
using HotelTravelMemories.Auth.Data.Dto;
using HotelTravelMemories.Auth.Data.Request;
using HotelTravelMemories.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelTravelMemories.Auth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;
        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            Result result = _cadastroService.Cadastrar(usuarioDto);
            
            if (result.IsFailed) 
                return StatusCode(500);

            return Ok(result.Successes);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivarContaUsuario([FromQuery] AtivaContaRequest ativaConta)
        {
            Result result = _cadastroService.AtivarContaUsuario(ativaConta);

            if (result.IsFailed)
                return StatusCode(500);

            return Ok(result.Successes);
        }
    }
}
