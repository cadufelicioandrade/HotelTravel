using FluentResults;
using HotelTravelMemories.API.DTO.Checkout;
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
    public class CheckoutController : ControllerBase
    {
        private CheckoutService _checkoutService;

        public CheckoutController(CheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
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

        [HttpPost]
        public IActionResult CreateCheckout([FromBody] CreateCheckoutDto createCheckout)
        {
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
