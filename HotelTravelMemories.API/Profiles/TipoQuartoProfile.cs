using AutoMapper;
using HotelTravelMemories.API.DTO.TipoQuarto;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class TipoQuartoProfile : Profile
    {
        public TipoQuartoProfile()
        {
            CreateMap<List<ReadTipoQuartoDto>, List<TipoQuarto>>();
            CreateMap<List<TipoQuarto>, List<ReadTipoQuartoDto>>();

            CreateMap<ReadTipoQuartoDto, TipoQuarto>();
            CreateMap<TipoQuarto, ReadTipoQuartoDto>();

            CreateMap<CreateTipoQuartoDto, TipoQuarto>();
            CreateMap<Cidade, CreateTipoQuartoDto>();

            CreateMap<UpdateTipoQuartoDto, TipoQuarto>();
            CreateMap<TipoQuarto, UpdateTipoQuartoDto>();
        }
    }
}
