using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns.Interfaces
{
    public interface IDesconto
    {
        void CalcularDesconto(ContaCliente orcamento);
        IDesconto ProximoDesconto { get; set; }

    }
}
