using FluentResults;
using HotelTravelMemories.API.DTO.Cidade;
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
    public class CidadeController : ControllerBase
    {
        private CidadeService _cidadeService;

        public CidadeController(CidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public IActionResult GetCidades()
        {
            List<ReadCidadeDto> cidadeDtos = _cidadeService.GetAll();

            if (cidadeDtos.Count <= 0)
                return NotFound();

            return Ok(cidadeDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCidadeById(int id)
        {
            ReadCidadeDto readCidade = _cidadeService.GetById(id);

            if (readCidade is null)
                return NotFound();

            return Ok(readCidade);
        }

        [HttpPost]
        public IActionResult CreateCidade([FromBody] CreateCidadeDto createCidade)
        {
            ReadCidadeDto readCidade = _cidadeService.Create(createCidade);
            return CreatedAtAction(nameof(GetCidadeById), new { Id = readCidade.Id }, readCidade);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCidade(int id, [FromBody] UpdateCidadeDto updateCidade)
        {
            Result result = _cidadeService.Update(id, updateCidade);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCidade(int id)
        {
            Result result = _cidadeService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

    }
}
