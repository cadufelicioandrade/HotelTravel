using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Clientes;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class ClienteService
    {
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public List<ReadClienteDto> GetAll()
        {
            return _mapper.Map<List<ReadClienteDto>>(_clienteRepository.GetAll());
        }

        public ReadClienteDto GetById(int id)
        {
            Cliente cliente = _clienteRepository.GetById(id);
            if (cliente is null)
                return null;
            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public ReadClienteDto Create(CreateClienteDto createCliente)
        {
            Cliente cliente = _mapper.Map<Cliente>(createCliente);
            _clienteRepository.Add(cliente);
            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public Result Update(int id, UpdateClienteDto updateCliente)
        {
            Cliente cliente = _clienteRepository.GetById(id);

            if (cliente is null)
                return Result.Fail("Cliente não localizado.");

            _mapper.Map(updateCliente, cliente);
            _clienteRepository.Update(cliente);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_clienteRepository.Delete(id))
                return Result.Fail("Cliente não localizado.");

            return Result.Ok();
        }
    }
}
