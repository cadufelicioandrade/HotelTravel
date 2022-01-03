using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Cidade
{
    public class CreateCidadeDto
    {
        public string City { get; set; }
        public string UF { get; set; }
        public string Estado { get; set; }
    }
}
