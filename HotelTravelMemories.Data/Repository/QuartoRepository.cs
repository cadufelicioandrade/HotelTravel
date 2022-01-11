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
    public class QuartoRepository : BaseRepository<Quarto>, IQuartoRepository
    {
        public QuartoRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }

        public List<Quarto> GetQuartoByStatus(bool status)
        {
            return _hotelContext.Quartos.Where(q => q.Disponivel == status).ToList();
        }
    }
}
