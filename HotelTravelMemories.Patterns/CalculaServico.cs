using HotelTravelMemories.Patterns.Interfaces;
using HotelTravelMemories.Patterns.ServicosQuartos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns
{
    public class CalculaServico
    {
        public void Calcular(Orcamento orcamento, IServico porcentagemServico)
        {
            porcentagemServico.Calcular(orcamento);
        }
    }
}
