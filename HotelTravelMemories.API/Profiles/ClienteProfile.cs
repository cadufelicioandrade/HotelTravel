using AutoMapper;
using HotelTravelMemories.API.DTO.Clientes;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<List<Cliente>, List<ReadClienteDto>>();
            CreateMap<List<ReadClienteDto>, List<Cliente>>();

            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, CreateClienteDto>();

            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<Cliente, UpdateClienteDto>();

            CreateMap<ReadClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();

        }


    }
}
