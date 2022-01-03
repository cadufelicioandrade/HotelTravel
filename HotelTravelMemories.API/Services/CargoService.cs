using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Cargos;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class CargoService
    {
        private ICargoRepository _cargoRepository;
        private IMapper _mapper;

        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public List<ReadCargoDto> GetAll()
        {
            return _mapper.Map<List<ReadCargoDto>>(_cargoRepository.GetAll());
        }

        public ReadCargoDto GetById(int id)
        {
            Cargo cargo = _cargoRepository.GetById(id);

            if (cargo is null)
                return null;

            return _mapper.Map<ReadCargoDto>(cargo);
        }

        public ReadCargoDto Create(CreateCargoDto createCargo)
        {
            Cargo cargo = _mapper.Map<Cargo>(createCargo);
            _cargoRepository.Add(cargo);
            return _mapper.Map<ReadCargoDto>(cargo); ;
        }

        public Result Update(int id, UpdateCargoDto updateCargo)
        {
            Cargo cargo = _cargoRepository.GetById(id);

            if (cargo is null)
                return Result.Fail("Cargo não localizado.");

            _mapper.Map(updateCargo, cargo);
            _cargoRepository.Update(cargo);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_cargoRepository.Delete(id))
                return Result.Fail("Cargo não localizado.");

            return Result.Ok();
        }
    }
}
