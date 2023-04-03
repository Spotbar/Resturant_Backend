using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.DataAccess.Models.Auth
{
    public class TokenModel
    {
       
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
