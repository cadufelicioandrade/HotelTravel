using FluentResults;
using HotelTravelMemories.API.DTO.Funcionario;
using HotelTravelMemories.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }


        [HttpGet]
        public IActionResult GetFuncionarios()
        {
            List<ReadFuncionarioDto> funcionarioDtos = _funcionarioService.GetAll();

            if (funcionarioDtos.Count <= 0)
                return NotFound();

            return Ok(funcionarioDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(int id)
        {
            ReadFuncionarioDto readFuncionario = _funcionarioService.GetById(id);

            if (readFuncionario is null)
                return NotFound();

            return Ok(readFuncionario);
        }

        [HttpPost]
        public IActionResult CreateFuncionario([FromBody] CreateFuncionarioDto createFuncionario)
        {
            ReadFuncionarioDto readFuncionario = _funcionarioService.Create(createFuncionario);
            return CreatedAtAction(nameof(GetFuncionarioById), new { Id = readFuncionario.Id }, readFuncionario);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFuncionario(int id, UpdateFuncionarioDto updateFuncionario)
        {
            //Funcionário realiza uma reserva atualizar com a reserva
            Result result = _funcionarioService.Update(id,updateFuncionario);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            Result result = _funcionarioService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarStatus(int id, [FromBody] bool ativar)
        {
            Result result = _funcionarioService.AlterarStatus(id, ativar);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok("Status alterado com sucesso!");
        }
    }
}
