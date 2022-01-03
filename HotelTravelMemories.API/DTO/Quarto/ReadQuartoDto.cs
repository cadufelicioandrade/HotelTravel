using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Quarto
{
    public class ReadQuartoDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Andar { get; set; }
        public bool Disponivel { get; set; }
        public object Reservas { get; set; }
        public int TipoQuartoId { get; set; }
        public object TipoQuarto { get; set; }
    }
}
