using HotelTravelMemories.Patterns.Descontos;
using HotelTravelMemories.Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns
{
    public class CalculaDesconto
    {
        public static void Calcular(ContaCliente orcamento)
        {
            IDesconto d1 = new DescQuinzeDias();
            IDesconto d2 = new DescTrintaDias();
            IDesconto d3 = new DescCupom();
            IDesconto semDesc = new SemDesconto();

            d1.ProximoDesconto = d2;
            d2.ProximoDesconto = d3;
            d3.ProximoDesconto = semDesc;

            d1.CalcularDesconto(orcamento);
        }
    }
}
