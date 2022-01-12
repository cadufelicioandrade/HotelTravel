using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.ServicosQuartos
{
    public class CoberturaServico : IServico
    {
        public void Calcular(ContaCliente orcamento)
        {
            if (orcamento.Servico.Cobertura > 0)
                orcamento.ValorTotal += (orcamento.ValorTotal * orcamento.Servico.Cobertura);
        }
    }
}
