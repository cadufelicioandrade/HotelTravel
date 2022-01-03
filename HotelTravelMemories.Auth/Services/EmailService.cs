using HotelTravelMemories.Auth.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Services
{
    public class EmailService
    {

        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(List<string> destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);

            MimeMessage msgMail = CriarCorpoEmail(mensagem);
            Enviar(msgMail);
        }

        private void Enviar(MimeMessage msgMail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                                    _configuration.GetValue<int>("EmailSettings:Port"), true);
                    
                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(msgMail);

                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    client.Disconnect(true);
                }

            }
        }

        private MimeMessage CriarCorpoEmail(Mensagem mensagem)
        {
            var msgMail = new MimeMessage();
            msgMail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            msgMail.To.AddRange(mensagem.Destinatario);
            msgMail.Subject = mensagem.Assunto;
            msgMail.Body = new TextPart(TextFormat.Text)
            {
                Text = mensagem.LinkAtivacao
            };

            return msgMail;
        }
    }
}
