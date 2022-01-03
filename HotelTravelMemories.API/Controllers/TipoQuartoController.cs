using FluentResults;
using HotelTravelMemories.API.DTO.TipoQuarto;
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
    public class TipoQuartoController : ControllerBase
    {
        private TipoQuartoService _tipoQuartoService;

        public TipoQuartoController(TipoQuartoService tipoQuartoService)
        {
            _tipoQuartoService = tipoQuartoService;
        }

        [HttpGet]
        public IActionResult GetTipoQuartos()
        {
            List<ReadTipoQuartoDto> tipoQuartoDtos = _tipoQuartoService.GetAll();

            if (tipoQuartoDtos.Count <= 0)
                return NotFound();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTipoQuartoById(int id)
        {
            ReadTipoQuartoDto readTipoQuarto = _tipoQuartoService.GetById(id);

            if (readTipoQuarto is null)
                return NotFound();

            return Ok(readTipoQuarto);
        }

        [HttpPost]
        public IActionResult CreateTipoQuarto([FromBody] CreateTipoQuartoDto createTipoQuarto)
        {
            ReadTipoQuartoDto readTipoQuarto = _tipoQuartoService.Create(createTipoQuarto);
            return CreatedAtAction(nameof(GetTipoQuartoById), new { Id = readTipoQuarto.Id }, readTipoQuarto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTipoQuarto(int id, [FromBody] UpdateTipoQuartoDto updateTipoQuarto)
        {
            Result result = _tipoQuartoService.Update(id, updateTipoQuarto);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoQuarto(int id)
        {
            Result result = _tipoQuartoService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }
    }
}
