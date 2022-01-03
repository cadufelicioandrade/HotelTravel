using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Quarto;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class QuartoService
    {
        private IQuartoRepository _quartoRepository;
        private IMapper _mapper;

        public QuartoService(IQuartoRepository quartoRepository, IMapper mapper)
        {
            _quartoRepository = quartoRepository;
            _mapper = mapper;
        }

        public List<ReadQuartoDto> GetAll()
        {
            return _mapper.Map<List<ReadQuartoDto>>(_quartoRepository.GetAll());
        }

        public ReadQuartoDto GetById(int id)
        {
            Quarto quarto = _quartoRepository.GetById(id);

            if (quarto is null)
                return null;

            return _mapper.Map<ReadQuartoDto>(quarto);
        }

        public ReadQuartoDto Create(CreateQuartoDto createQuarto)
        {
            Quarto quarto = _mapper.Map<Quarto>(createQuarto);
            _quartoRepository.Add(quarto);
            return _mapper.Map<ReadQuartoDto>(quarto);
        }

        public Result Update(int id, UpdateQuartoDto updateQuarto)
        {
            Quarto quarto = _quartoRepository.GetById(id);

            if (quarto is null)
                return Result.Fail("Quarto não localizado.");

            _mapper.Map(updateQuarto, quarto);
            _quartoRepository.Update(quarto);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_quartoRepository.Delete(id))
                return Result.Fail("Quarto não localizado.");

            return Result.Ok();
        }
    }
}
