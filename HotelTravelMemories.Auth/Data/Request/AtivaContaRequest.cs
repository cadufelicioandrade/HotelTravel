using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.Auth.Data.Request
{
    public class AtivaContaRequest
    {
        public AtivaContaRequest()
        {

        }

        [Required]
        public int UsuarioId { get; set; }
        
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}
