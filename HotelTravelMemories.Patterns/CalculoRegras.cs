using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns
{
    public class CalculoRegras
    {

        private ContaCliente _orcamento = null;

        public CalculoRegras(ContaCliente orcamento)
        {
            _orcamento = orcamento;
        }

        public ContaCliente CalcularDescontosEservicos()
        {
            CalculaDesconto.Calcular(this._orcamento);
            CalculaServico.Calcular(this._orcamento);
            return this._orcamento;
        }

    }
}
