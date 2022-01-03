using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Quarto
    {
        public Quarto()
        {

        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public int Andar { get; set; }
        public bool Disponivel { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
        public int TipoQuartoId { get; set; }
        public virtual TipoQuarto TipoQuarto { get; set; }

    }
}
