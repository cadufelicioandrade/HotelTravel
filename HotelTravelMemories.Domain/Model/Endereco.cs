using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Domain.Model
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }

    }
}
