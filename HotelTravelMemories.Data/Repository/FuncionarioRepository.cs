using HotelTravelMemories.Data.Context;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }

        public bool AlterarStatus(int id, bool ativar)
        {
            try
            {
                var funcionario = GetById(id);
                funcionario.Ativo = ativar;
                Update(funcionario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
