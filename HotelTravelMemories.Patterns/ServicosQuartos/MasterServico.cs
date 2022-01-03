using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.ServicosQuartos
{
    public class MasterServico : IServico
    {
        public void Calcular(Orcamento orcamento)
        {
            if (orcamento.Servico.Master > 0)
                orcamento.ValorTotal += (orcamento.ValorTotal * orcamento.Servico.Master);
        }
    }
}
