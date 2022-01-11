using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Funcionario
    {
        public Funcionario()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int CargoId { get; set; }
        public bool Ativo { get; set; }
        public virtual Cargo Cargo { get; set; }

        public virtual Endereco Endereco { get; set; }

        public virtual List<Reserva> Reservas { get; set; }

    }
}
