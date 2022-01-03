using AutoMapper;
using HotelTravelMemories.API.DTO.Funcionario;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<List<ReadFuncionarioDto>, List<Funcionario>>();
            CreateMap<List<Funcionario>, List<ReadFuncionarioDto>>();

            CreateMap<ReadFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDto>();

            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, CreateFuncionarioDto>();

            CreateMap<UpdateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, UpdateFuncionarioDto>();
        }

    }
}
