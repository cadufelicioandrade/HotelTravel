using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Funcionario;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class FuncionarioService
    {
        private IFuncionarioRepository _funcionarioRepository;
        private IMapper _mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public List<ReadFuncionarioDto> GetAll()
        {
            return _mapper.Map<List<ReadFuncionarioDto>>(_funcionarioRepository.GetAll());
        }

        public ReadFuncionarioDto GetById(int id)
        {
            Funcionario funcionario = _funcionarioRepository.GetById(id);

            if (funcionario is null)
                return null;

            return _mapper.Map<ReadFuncionarioDto>(funcionario);
        }

        public ReadFuncionarioDto Create(CreateFuncionarioDto createFuncionario)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(createFuncionario);
            _funcionarioRepository.Add(funcionario);
            return _mapper.Map<ReadFuncionarioDto>(funcionario);
        }

        public Result Update(int id, UpdateFuncionarioDto updateFuncionario)
        {
            Funcionario funcionario = _funcionarioRepository.GetById(id);

            if (funcionario is null)
                return Result.Fail("Funcionário não localizado.");

            _mapper.Map(updateFuncionario, funcionario);
            _funcionarioRepository.Update(funcionario);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if (!_funcionarioRepository.Delete(id))
                return Result.Fail("Funcionário não localizado.");

            return Result.Ok();
        }

        public Result AlterarStatus(int id, bool ativar)
        {
            if(!_funcionarioRepository.AlterarStatus(id, ativar))
                return Result.Fail("Funcionário não localizado.");

            return Result.Ok();
        }
    }
}
