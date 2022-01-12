using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Reserva;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class ReservaService
    {
        private IReservaRepository _reservaRepository;
        private IMapper _mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public List<ReadReservaDto> GetAll()
        {
            return _mapper.Map<List<ReadReservaDto>>(_reservaRepository.GetAll());
        }

        public ReadReservaDto GetById(int id)
        {
            Reserva reserva = _reservaRepository.GetById(id);

            if (reserva is null)
                return null;

            return _mapper.Map<ReadReservaDto>(reserva);
        }

        public ReadReservaDto Create(CreateReservaDto createReserva)
        {
            Reserva reserva = _mapper.Map<Reserva>(createReserva);
            _reservaRepository.Add(reserva);
            return _mapper.Map<ReadReservaDto>(reserva);
        }

        public Result Update(int id, UpdateReservaDto updateReserva)
        {
            Reserva reserva = _reservaRepository.GetById(id);

            if (reserva is null)
                return Result.Fail("Reserva não localizada.");

            _mapper.Map(updateReserva, reserva);
            _reservaRepository.Update(reserva);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_reservaRepository.Delete(id))
                return Result.Fail("Reserva não localizad.");

            return Result.Ok();
        }

        public Reserva ToReserva(ReadReservaDto readReservaDto)
        {
            return _mapper.Map<Reserva>(readReservaDto);
        }
    }
}
