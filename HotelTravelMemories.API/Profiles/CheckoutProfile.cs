using AutoMapper;
using HotelTravelMemories.API.DTO.Checkout;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<List<ReadCheckoutDto>, List<Checkout>>();
            CreateMap<List<Checkout>, List<ReadCheckoutDto>>();

            CreateMap<ReadCheckoutDto, Checkout>();
            CreateMap<Checkout, ReadCheckoutDto>();

            CreateMap<CreateCheckoutDto, Checkout>();
            CreateMap<Checkout, CreateCheckoutDto>();

            CreateMap<UpdateCheckoutDto, Checkout>();
            CreateMap<Checkout, UpdateCheckoutDto>();

        }
    }
}
