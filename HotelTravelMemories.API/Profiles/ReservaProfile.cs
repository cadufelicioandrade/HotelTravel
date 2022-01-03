using AutoMapper;
using HotelTravelMemories.API.DTO.Reserva;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<List<ReadReservaDto>, List<Reserva>>();
            CreateMap<List<Reserva>, List<ReadReservaDto>>();

            CreateMap<ReadReservaDto, Reserva>();
            CreateMap<Reserva, ReadReservaDto>();

            CreateMap<CreateReservaDto, Reserva>();
            CreateMap<Cidade, CreateReservaDto>();

            CreateMap<UpdateReservaDto, Reserva>();
            CreateMap<Reserva, UpdateReservaDto>();
        }
    }
}
