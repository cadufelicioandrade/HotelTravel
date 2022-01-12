using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns
{
    public class ContaCliente
    {
        public double ValorDiaria { get; set; }
        public int QuantidadeDias { get; set; }
        public double ValorTotal { get; set; }
        public bool CupomDesconto { get; set; }
        public PorcentagemSobreServico Servico { get; set; }

        public ContaCliente(double valorDiaria, 
                        int quantidadeDias, 
                        PorcentagemSobreServico servico, 
                        bool cartaoDesconto)
        {
            this.ValorDiaria = valorDiaria;
            this.QuantidadeDias = quantidadeDias;
            this.Servico = servico;
            this.CupomDesconto = cartaoDesconto;
        }
    }
}
