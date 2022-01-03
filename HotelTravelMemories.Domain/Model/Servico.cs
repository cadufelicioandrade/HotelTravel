using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Servico
    {
        public Servico()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }

        public int ReservaId { get; set; }
        public virtual Reserva Reserva { get; set; }

    }
}
