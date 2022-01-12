using HotelTravelMemories.Patterns.Enums;
using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.Descontos
{
    public class DescQuinzeDias : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public void CalcularDesconto(ContaCliente orcamento)
        {
            if (orcamento.QuantidadeDias > 15 && orcamento.QuantidadeDias <= 30 && !orcamento.CupomDesconto)
                orcamento.ValorTotal -= (orcamento.ValorTotal * (Convert.ToInt32(ePorcentagem.dois) / 100));
            else
                ProximoDesconto.CalcularDesconto(orcamento);
        }
    }
}
