using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Reserva
{
    public class CreateReservaDto
    {
        public DateTime DtReserva { get; set; }
        public DateTime DtInclusao { get; set; }
        public object Cliente { get; set; }
        public int ClienteId { get; set; }
        public object Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public double Sinal { get; set; }
        public int QuartoId { get; set; }
        public object Quarto { get; set; }
        public object Servicos { get; set; }

        public int CheckoutId { get; set; }
        public object Checkout { get; set; }
    }
}
