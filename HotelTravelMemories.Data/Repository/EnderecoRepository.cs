﻿using HotelTravelMemories.Data.Context;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }
    }
}
