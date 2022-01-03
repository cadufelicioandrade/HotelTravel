using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Funcionario
{
    public class UpdateFuncionarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int CargoId { get; set; }
        public object Cargo { get; set; }

        public object Endereco { get; set; }

        public object Reservas { get; set; }
    }
}
