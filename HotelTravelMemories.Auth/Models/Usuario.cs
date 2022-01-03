using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
