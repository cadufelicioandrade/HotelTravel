using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Reserva
    {
        public Reserva()
        {

        }

        public int Id { get; set; }
        public DateTime DtReserva { get; set; }
        public DateTime DtInclusao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public double Sinal { get; set; }
        public virtual Quarto Quarto { get; set; }
        public int QuartoId { get; set; }

        public virtual List<Servico> Servicos { get; set; }

        public virtual Checkout Checkout { get; set; }
        public int? CheckoutId { get; set; }

        public int GetAllDays()
        {
            return (this.DtReserva - DateTime.Now).Days;
        }

    }
}
