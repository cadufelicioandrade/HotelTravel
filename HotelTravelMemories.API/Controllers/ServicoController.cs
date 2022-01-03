using FluentResults;
using HotelTravelMemories.API.DTO.Servico;
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
    public class ServicoController : ControllerBase
    {
        private ServicicoService _servicicoService;

        public ServicoController(ServicicoService servicicoService)
        {
            _servicicoService = servicicoService;
        }


        [HttpGet]
        public IActionResult GetServicos()
        {
            List<ReadServicoDto> servicoDtos = _servicicoService.GetAll();

            if (servicoDtos.Count <= 0)
                return NotFound();

            return Ok(servicoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetServicoById(int id)
        {
            ReadServicoDto readServico = _servicicoService.GetById(id);

            if (readServico is null)
                return NotFound();

            return Ok(readServico);
        }

        [HttpPost]
        public IActionResult CreateServico([FromBody] CreateServicoDto createServico)
        {
            ReadServicoDto readServico = _servicicoService.Create(createServico);
            return CreatedAtAction(nameof(GetServicoById), new { Id = readServico.Id }, readServico);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServico(int id, [FromBody] UpdateServicoDto updateServico)
        {
            Result result = _servicicoService.Update(id, updateServico);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServico(int id)
        {
            Result result = _servicicoService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

    }
}
