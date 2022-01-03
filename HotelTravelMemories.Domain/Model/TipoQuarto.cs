using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class TipoQuarto
    {
        public TipoQuarto()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public double ValorDiaria { get; set; }

        public virtual List<Quarto> Quartos { get; set; }
    }
}
