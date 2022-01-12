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
            #region JSON Create Reserva
            //{
            //  "DtReserva":"2022-01-12",
            //	"DtInclusao":"2022-01-12",
            //	"Cliente": {
            //				"Id":1,
            //		        "Nome":"teste",
            //		        "Email":"teste@teste.com",
            //		        "RG":"12332111",
            //		        "CPF":"2223334455",
            //		        "Telefone":"1123324554",
            //		        "Celular":"11923331222",
            //		        "Endereco": {
            //		        	           "Id":1,
            //		        	           "Logradouro":"Rua: teste",
            //		        	           "Bairro": "Teste",
            //		        	           "CEP":"0000000",
            //		        	           "Complemento":"",
            //		        	           "Numero":123,
            //		        	           "ClientId":1,
            //		        	           "FuncionarioId":null,
            //		        	           "CidadeId":1
            //  	        	       }
            //			},
            //	"ClienteId": 1,
            //	"Fucionario":{
            //		         "Id":1,
            //		         "Nome":"teste",
            //		         "Email":"teste@teste.com",
            //		         "RG":"223334445",
            //		         "CPF":"22233344455",
            //		         "Telefone":"1122334455",
            //		         "Celular":"119887766554",
            //		         "CargoId":1,
            //		         "Ativo":true,
            //		         "Cargo": {
            //						    "Id":1,
            //			                "Descricao":"Recepcionista"
            //              },
            //	            "Endereco":{
            //	            		    "Id":2,
            //	            		    "Logradouro":"Rua: teste",
            //	            		    "Bairro": "Teste",
            //	            		    "CEP":"0000000",
            //	            		    "Complemento":"",
            //	            		    "Numero":123,
            //	            		    "ClientId":null,
            //	            		    "FuncionarioId":1,
            //	            		    "CidadeId":1
            //	            	        }
            //			},
            //	"FuncionarioId":1,
            //	"Sinal":0,
            //	"Quarto":{
            //		        "Id":1,
            //		        "Numero":1,
            //		        "Andar":1,
            //		        "Disponivel":true,
            //		        TipoQuarto: {
            //						        "Id":1,
            //			                    "Descricao":"teste",
            //			                    "ValorDiaria":70
            //		                    }
            //				},
            //	"QuartoId": 1,
            //}
            #endregion

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
