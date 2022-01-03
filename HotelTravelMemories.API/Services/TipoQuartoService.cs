using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.TipoQuarto;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class TipoQuartoService
    {
        private ITipoQuartoRepository _tipoQuartoRepository;
        private IMapper _mapper;

        public TipoQuartoService(ITipoQuartoRepository tipoQuartoRepository, IMapper mapper)
        {
            _tipoQuartoRepository = tipoQuartoRepository;
            _mapper = mapper;
        }

        public List<ReadTipoQuartoDto> GetAll()
        {
            return _mapper.Map<List<ReadTipoQuartoDto>>(_tipoQuartoRepository.GetAll());
        }

        public ReadTipoQuartoDto GetById(int id)
        {
            TipoQuarto tipoQuarto = _tipoQuartoRepository.GetById(id);

            if (tipoQuarto is null)
                return null;

            return _mapper.Map<ReadTipoQuartoDto>(tipoQuarto);
        }

        public ReadTipoQuartoDto Create(CreateTipoQuartoDto createTipoQuarto)
        {
            TipoQuarto tipoQuarto = _mapper.Map<TipoQuarto>(createTipoQuarto);
            _tipoQuartoRepository.Add(tipoQuarto);
            return _mapper.Map<ReadTipoQuartoDto>(tipoQuarto);
        }

        public Result Update(int id, UpdateTipoQuartoDto updateTipoQuarto)
        {
            TipoQuarto tipoQuarto = _tipoQuartoRepository.GetById(id);

            if (tipoQuarto is null)
                return Result.Fail("Tipo Quarto não localizado.");

            _mapper.Map(updateTipoQuarto, tipoQuarto);
            _tipoQuartoRepository.Update(tipoQuarto);
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_tipoQuartoRepository.Delete(id))
                return Result.Fail("Tipo Quarto não localiado.");
            return Result.Ok();
        }
    }
}
