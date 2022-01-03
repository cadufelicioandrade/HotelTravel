using AutoMapper;
using HotelTravelMemories.API.DTO.Servico;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<List<ReadServicoDto>, List<Servico>>();
            CreateMap<List<Servico>, List<ReadServicoDto>>();

            CreateMap<ReadServicoDto, Servico>();
            CreateMap<Servico, ReadServicoDto>();

            CreateMap<CreateServicoDto, Servico>();
            CreateMap<Cidade, CreateServicoDto>();

            CreateMap<UpdateServicoDto, Servico>();
            CreateMap<Servico, UpdateServicoDto>();
        }
    }
}
