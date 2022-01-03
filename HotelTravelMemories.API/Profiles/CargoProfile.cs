using AutoMapper;
using HotelTravelMemories.API.DTO.Cargos;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Profiles
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CreateCargoDto, Cargo>();
            CreateMap<Cargo, CreateCargoDto>();

            CreateMap<ReadCargoDto, Cargo>();
            CreateMap<Cargo, ReadCargoDto>();

            CreateMap<UpdateCargoDto, Cargo>();
            CreateMap<Cargo, UpdateCargoDto>();

            CreateMap<List<ReadCargoDto>, List<Cargo>>();
            CreateMap<List<Cargo>, List<ReadCargoDto>>();
        }
    }
}
