using FluentResults;
using HotelTravelMemories.API.DTO.Cargos;
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
    public class CargoController : ControllerBase
    {

        private CargoService _cargoService;

        public CargoController(CargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult GetCargos()
        {
            List<ReadCargoDto> cargoDtos = _cargoService.GetAll();

            if (cargoDtos.Count <= 0)
                return NotFound();

            return Ok(cargoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoById(int id)
        {
            ReadCargoDto readCargo = _cargoService.GetById(id);

            if (readCargo is null)
                return NotFound();

            return Ok(readCargo);
        }

        [HttpPost]
        public IActionResult CreateCargo([FromBody] CreateCargoDto createCargo)
        {
            ReadCargoDto readCargo = _cargoService.Create(createCargo);
            return CreatedAtAction(nameof(GetCargoById), new { Id = readCargo.Id }, readCargo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCargo(int id, UpdateCargoDto updateCargo)
        {
            Result result = _cargoService.Update(id, updateCargo);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargo(int id)
        {
            Result result = _cargoService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

    }
}
