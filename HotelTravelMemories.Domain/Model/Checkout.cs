using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Checkout
    {
        public Checkout()
        {

        }

        public int Id { get; set; }
        public int QtdDiarias { get; set; }
        public double ValorDiaria { get; set; }
        public double Total { get; set; }
        public DateTime DtCheckout { get; set; }
        public virtual Reserva Reserva { get; set; }
        public int ReservaId { get; set; }

    }
}
