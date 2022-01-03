using AutoMapper;
using HotelTravelMemories.API.DTO.Cidade;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class CidadeProfile : Profile
    {
        public CidadeProfile()
        {
            CreateMap<List<ReadCidadeDto>, List<Cidade>>();
            CreateMap<List<Cidade>, List<ReadCidadeDto>>();

            CreateMap<ReadCidadeDto, Cidade>();
            CreateMap<Cidade, ReadCidadeDto>();

            CreateMap<CreateCidadeDto, Cidade>();
            CreateMap<Cidade, CreateCidadeDto>();

            CreateMap<UpdateCidadeDto, Cidade>();
            CreateMap<Cidade, UpdateCidadeDto>();
        }
    }
}
