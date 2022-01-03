using HotelTravelMemories.Patterns.Enums;
using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.Descontos
{
    public class DescCupom : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public void CalcularDesconto(Orcamento orcamento)
        {
            if (orcamento.CupomDesconto)
                orcamento.ValorTotal -= (orcamento.ValorTotal * (Convert.ToInt32(ePorcentagem.cinco) / 100));
            else
                ProximoDesconto.CalcularDesconto(orcamento);
        }
    }
}
