using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Patterns
{
    public class PorcentagemSobreServico
    {
        public double TradicionalCasal { get; private set; }
        public double TradicionalSolteiro { get; private set; }
        public double Premium { get; private set; }
        public double Master { get; private set; }
        public double Cobertura { get; private set; }

        public PorcentagemSobreServico(double tradicionalSolterio = 0, 
                                    double tradicionalCasal = 0,
                                    double premium = 0, 
                                    double master = 0, 
                                    double cobertura = 0)
        {
            this.TradicionalSolteiro = tradicionalSolterio;
            this.TradicionalCasal = tradicionalCasal;
            this.Premium = premium;
            this.Master = master;
            this.Cobertura = cobertura;
        }
    }
}
