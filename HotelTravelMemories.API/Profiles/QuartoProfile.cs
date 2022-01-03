using AutoMapper;
using HotelTravelMemories.API.DTO.Quarto;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class QuartoProfile : Profile
    {
        public QuartoProfile()
        {
            CreateMap<List<ReadQuartoDto>, List<Quarto>>();
            CreateMap<List<Quarto>, List<ReadQuartoDto>>();

            CreateMap<ReadQuartoDto, Quarto>();
            CreateMap<Quarto, ReadQuartoDto>();

            CreateMap<CreateQuartoDto, Quarto>();
            CreateMap<Quarto, CreateQuartoDto>();

            CreateMap<CreateQuartoDto, Quarto>();
            CreateMap<Quarto, UpdateQuartoDto>();
        }
    }
}
