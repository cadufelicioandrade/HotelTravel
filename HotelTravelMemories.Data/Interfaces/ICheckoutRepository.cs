﻿using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Interfaces
{
    public interface ICheckoutRepository : IBaseRepository<Checkout>
    {
        Checkout GetCheckoutByCliente(int ClienteId);
    }
}
