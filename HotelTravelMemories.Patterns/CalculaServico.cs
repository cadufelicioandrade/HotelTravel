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
        public static void Calcular(ContaCliente orcamento )
        {
            List<IServico> porcentagemServicos = new List<IServico>()
            {
                new CoberturaServico(), new MasterServico(), new PremiumServico(), new TradicionalCasalServico(), new TradicionalSolteiroServico()
            };

            foreach (IServico servico in porcentagemServicos)
            {
                servico.Calcular(orcamento);
            }
        }
    }
}
