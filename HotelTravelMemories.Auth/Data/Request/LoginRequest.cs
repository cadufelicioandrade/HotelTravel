using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Data.Request
{
    public class LoginRequest
    {
        public LoginRequest()
        {

        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
