using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Servico
{
    public class CreateServicoDto
    {
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        public int ReservaId { get; set; }
        public object Reserva { get; set; }
    }
}
