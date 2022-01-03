using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Servico;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class ServicicoService
    {
        private IServicoRepository _servicoRepository;
        private IMapper _mapper;

        public ServicicoService(IServicoRepository servicoRepository, IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public List<ReadServicoDto> GetAll()
        {
            return _mapper.Map<List<ReadServicoDto>>(_servicoRepository.GetAll());
        }

        public ReadServicoDto GetById(int id)
        {
            Servico servico = _servicoRepository.GetById(id);

            if (servico is null)
                return null;

            return _mapper.Map<ReadServicoDto>(servico);
        }

        public ReadServicoDto Create(CreateServicoDto createServico)
        {
            Servico servico = _mapper.Map<Servico>(createServico);
            _servicoRepository.Add(servico);
            return _mapper.Map<ReadServicoDto>(servico);
        }

        public Result Update(int id, UpdateServicoDto updateServico)
        {
            Servico servico = _servicoRepository.GetById(id);

            if (servico is null)
                return Result.Fail("Serviço não encontrado.");

            _mapper.Map(updateServico, servico);
            _servicoRepository.Update(servico);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_servicoRepository.Delete(id))
                return Result.Fail("Serviço não localizado.");

            return Result.Ok();
        }


    }
}
