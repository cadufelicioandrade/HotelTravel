using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Endereco;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class EnderecoService
    {
        private IEnderecoRepository _enderecoRepository;
        private IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public List<ReadEnderecoDto> GetAll()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_enderecoRepository.GetAll());
        }

        public ReadEnderecoDto GetById(int id)
        {
            Endereco endereco = _enderecoRepository.GetById(id);
            
            if (endereco is null)
                return null;

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public ReadEnderecoDto Create(CreateEnderecoDto createEndereco)
        {
            Endereco endereco = _mapper.Map<Endereco>(createEndereco);
            _enderecoRepository.Add(endereco);
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public Result Update(int id, UpdateEnderecoDto updateEndereco)
        {
            Endereco endereco = _enderecoRepository.GetById(id);

            if (endereco is null)
                return Result.Fail("Endereço nãolocalizado.");

            _mapper.Map(updateEndereco, endereco);
            _enderecoRepository.Update(endereco);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_enderecoRepository.Delete(id))
                return Result.Fail("Endereco não localizado.");

            return Result.Ok();
        }
    }
}
