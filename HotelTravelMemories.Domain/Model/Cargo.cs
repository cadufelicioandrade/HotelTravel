using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Cargo
    {
        public Cargo()
        {

        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual List<Funcionario> Funcionario { get; set; }

    }
}
