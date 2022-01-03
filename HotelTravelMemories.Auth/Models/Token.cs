using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Models
{
    public class Token
    {
        public Token(string valor)
        {
            this.Valor = valor;
        }

        public string Valor { get; set; }
    }
}
