using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Checkout
{
    public class ReadCheckoutDto
    {
        public ReadCheckoutDto()
        {

        }
        public int Id { get; set; }
        public int QtdDiarias { get; set; }
        public double ValorDiaria { get; set; }
        public double Total { get; set; }
        public DateTime DtCheckout { get; set; }
        public object Reserva { get; set; }
        public int ReservaId { get; set; }
    }
}
