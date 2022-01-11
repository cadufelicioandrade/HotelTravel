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
    public class CheckouRepository : BaseRepository<Checkout>, ICheckoutRepository
    {
        public CheckouRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }

        public Checkout GetCheckoutByCliente(int ClienteId)
        {
            Checkout checkout = _hotelContext.Checkouts.FirstOrDefault(c => c.Id.Equals(ClienteId));
            return checkout;
        }
    }
}
