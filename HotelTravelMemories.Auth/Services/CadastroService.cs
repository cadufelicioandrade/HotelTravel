using AutoMapper;
using FluentResults;
using HotelTravelMemories.Auth.Data.Dto;
using HotelTravelMemories.Auth.Data.Request;
using HotelTravelMemories.Auth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HotelTravelMemories.Auth.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result Cadastrar(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            var resultIdentity = _userManager.CreateAsync(identityUser, usuarioDto.Password);

            if (resultIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                var destinatario = new List<string>();
                destinatario.Add(identityUser.Email);

                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(destinatario, "Assunto", identityUser.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            }

            return Result.Fail("Falha no cadastro de usuário.");
        }

        public Result AtivarContaUsuario(AtivaContaRequest ativaConta)
        {
            IdentityUser<int> userIdentity = _userManager.Users.FirstOrDefault(u => u.Id == ativaConta.UsuarioId);
            var resultIdentity = _userManager.ConfirmEmailAsync(userIdentity, ativaConta.CodigoAtivacao).Result;

            if (resultIdentity.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Falha ao ativar conta usuário.");
        }
    }
}
