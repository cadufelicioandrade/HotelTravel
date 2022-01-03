using AutoMapper;
using HotelTravelMemories.API.DTO.Endereco;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<List<ReadEnderecoDto>, List<Endereco>>();
            CreateMap<List<Endereco>, List<ReadEnderecoDto>>();

            CreateMap<ReadEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();

            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, UpdateEnderecoDto>();

            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, CreateEnderecoDto>();
        }
    }
}
