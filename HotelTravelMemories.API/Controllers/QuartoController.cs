using FluentResults;
using HotelTravelMemories.API.DTO.Quarto;
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
    public class QuartoController : ControllerBase
    {
        private QuartoService _quartoService;

        public QuartoController(QuartoService quartoService)
        {
            _quartoService = quartoService;
        }


        [HttpGet]
        public IActionResult GetQuarto()
        {
            List<ReadQuartoDto> quartoDtos = _quartoService.GetAll();

            if (quartoDtos.Count <= 0)
                return NotFound();

            return Ok(quartoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuartoById(int id)
        {
            ReadQuartoDto readQuarto = _quartoService.GetById(id);

            if (readQuarto is null)
                return NotFound();

            return Ok(readQuarto);
        }

        [HttpGet("{status}")]
        public IActionResult GetQuartosByStatus(bool status)
        {
            List<ReadQuartoDto> quartoDtos = _quartoService.GetQuartoByStatus(status);

            if (quartoDtos.Count <= 0)
                return NotFound("Nenhum quarto localizado.");

            return Ok(quartoDtos);
        }

        [HttpPost]
        public IActionResult CreateQuarto([FromBody] CreateQuartoDto createQuarto)
        {
            ReadQuartoDto readQuarto = _quartoService.Create(createQuarto);
            return CreatedAtAction(nameof(readQuarto), new { Id = readQuarto.Id }, readQuarto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuarto(int id, [FromBody] UpdateQuartoDto updateQuarto)
        {
            Result result = _quartoService.Update(id, updateQuarto);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuarto(int id)
        {
            Result result = _quartoService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

    }
}
