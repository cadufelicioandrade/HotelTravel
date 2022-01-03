using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Cidade;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class CidadeService
    {
        private ICidadeRepository _cidadeRepository;
        private IMapper _mapper;

        public CidadeService(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public List<ReadCidadeDto> GetAll()
        {
            return _mapper.Map<List<ReadCidadeDto>>(_cidadeRepository.GetAll());
        }

        public ReadCidadeDto GetById(int id)
        {
            Cidade cidade = _cidadeRepository.GetById(id);

            if (cidade is null)
                return null;

            return _mapper.Map<ReadCidadeDto>(cidade);
        }

        public ReadCidadeDto Create(CreateCidadeDto createCidade)
        {
            Cidade cidade = _mapper.Map<Cidade>(createCidade);
            _cidadeRepository.Add(cidade);
            return _mapper.Map<ReadCidadeDto>(cidade);
        }

        public Result Update(int id, UpdateCidadeDto updateCidade)
        {
            Cidade cidade = _cidadeRepository.GetById(id);

            if (cidade is null)
                return Result.Fail("Cidade não localizada.");

            _mapper.Map(updateCidade, cidade);
            _cidadeRepository.Update(cidade);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_cidadeRepository.Delete(id))
                return Result.Fail("Cidade não localizada.");

            return Result.Ok();
        }
    }
}
