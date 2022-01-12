using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.Descontos
{
    public class SemDesconto : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public void CalcularDesconto(ContaCliente orcamento)
        {
            orcamento.ValorTotal -= 0;
        }
    }
}
