using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Cidade
{
    public class ReadCidadeDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Estado { get; set; }

        public object Enderecos { get; set; }
    }
}
