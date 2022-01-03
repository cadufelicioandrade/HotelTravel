using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Cidade
    {
        public Cidade()
        {

        }

        public int Id { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Estado { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }

    }
}
