using Microsoft.AspNetCore.Mvc;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.API.Services;
using HotelTravelMemories.API.DTO.Clientes;

namespace HotelTravelMemories.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            List<ReadClienteDto> clientesDto = _clienteService.GetAll();

            if (clientesDto.Count <= 0)
                return NotFound();

            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            ReadClienteDto clienteDto = _clienteService.GetById(id);

            if (clienteDto is null)
                return NotFound();

            return Ok(clienteDto);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] CreateClienteDto clienteDto)
        {
            ReadClienteDto readCliente = _clienteService.Create(clienteDto);
            return CreatedAtAction(nameof(GetClienteById), new { Id = readCliente.Id }, readCliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente( int id, [FromBody] UpdateClienteDto updateCliente)
        {
             Result result = _clienteService.Update(id, updateCliente);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            Result result = _clienteService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }
    }
}
