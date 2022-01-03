using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.DTO.Endereco
{
    public class CreateEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }


        public int? ClienteId { get; set; }
        public object Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public object Funcionario { get; set; }

        public int CidadeId { get; set; }
        public object Cidade { get; set; }
    }
}
