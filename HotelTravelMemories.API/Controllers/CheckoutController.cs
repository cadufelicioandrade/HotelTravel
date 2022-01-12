using FluentResults;
using HotelTravelMemories.API.DTO.Checkout;
using HotelTravelMemories.API.DTO.Reserva;
using HotelTravelMemories.API.Services;
using HotelTravelMemories.Domain.Model;
using HotelTravelMemories.Patterns;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private CheckoutService _checkoutService;
        private ReservaService _reservaService;

        public CheckoutController(CheckoutService checkoutService, ReservaService reservaService)
        {
            _checkoutService = checkoutService;
            _reservaService = reservaService;
        }

        public IActionResult GetCheckouts()
        {
            List<ReadCheckoutDto> checkoutDtos = _checkoutService.GetAll();

            if (checkoutDtos.Count <= 0)
                return NotFound();

            return Ok(checkoutDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCheckouById(int id)
        {
            ReadCheckoutDto readCheckout = _checkoutService.GetById(id);

            if (readCheckout is null)
                return NotFound();

            return Ok(readCheckout);
        }

        [HttpGet("{clienteId")]
        public IActionResult GetCheckoutByCliente(int clienteId)
        {
            ReadCheckoutDto readCheckout = _checkoutService.GetCheckoutByCliente(clienteId);

            if (readCheckout is null)
                return NotFound("Cliente não localizado para está conta.");

            return Ok(readCheckout);
        }

        [HttpPost("{cartaoDeDescontos}")]
        public IActionResult CreateCheckout([FromBody] ReadReservaDto readReservaDto, bool cartaoDeDescontos)
        {
            #region JSON read Reserva para finalizar com checkout
            //{
            //  "Id":1,
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

            Reserva reserva = _reservaService.ToReserva(readReservaDto);

            ContaCliente contaCliente = new ContaCliente(reserva.Quarto.TipoQuarto.ValorDiaria,
                                                reserva.GetAllDays(), 
                                                new PorcentagemSobreServico(), 
                                                cartaoDeDescontos);

            CalculoRegras calculoRegras = new CalculoRegras(contaCliente);
            var contaCalculada = calculoRegras.CalcularDescontosEservicos();

            CreateCheckoutDto createCheckout = new CreateCheckoutDto();
            createCheckout.DtCheckout = DateTime.Now;
            createCheckout.QtdDiarias = reserva.GetAllDays();
            createCheckout.Reserva = reserva;
            createCheckout.ReservaId = reserva.Id;
            createCheckout.Total = contaCalculada.ValorTotal;
            createCheckout.ValorDiaria = contaCliente.ValorDiaria;

            ReadCheckoutDto readCheckout = _checkoutService.Create(createCheckout);
            return CreatedAtAction(nameof(GetCheckouById), new { Id = readCheckout.Id }, readCheckout);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCheckout(int id, [FromBody] UpdateCheckoutDto updateCheckout)
        {
            Result result = _checkoutService.Update(id, updateCheckout);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCheckout(int id)
        {
            Result result = _checkoutService.Delete(id);

            if (result.IsFailed)
                return NotFound(result.Errors[0].Message);

            return NoContent();
        }

    }
}
