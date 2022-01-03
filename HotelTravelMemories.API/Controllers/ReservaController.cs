using FluentResults;
using HotelTravelMemories.API.DTO.Reserva;
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
    public class ReservaController : ControllerBase
    {
        private ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public IActionResult GetReservas()
        {
            List<ReadReservaDto> reservaDtos = _reservaService.GetAll();

            if (reservaDtos.Count <= 0)
                return NotFound();

            return Ok(reservaDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservaById(int id)
        {
            ReadReservaDto readReserva = _reservaService.GetById(id);

            if (readReserva is null)
                return NotFound();

            return Ok(readReserva);
        }

        [HttpPost]
        public IActionResult CreateReserva([FromBody] CreateReservaDto createReserva)
        {
            ReadReservaDto readReserva = _reservaService.Create(createReserva);
            return CreatedAtAction(nameof(GetReservaById), new { Id = readReserva.Id }, readReserva);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReserva(int id, [FromBody] UpdateReservaDto updateReserva)
        {
            Result result = _reservaService.Update(id, updateReserva);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReserva(int id)
        {
            Result result = _reservaService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

    }
}
