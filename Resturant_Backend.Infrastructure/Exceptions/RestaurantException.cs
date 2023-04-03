using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.Infrastructure.Exceptions
{
    public class RestaurantException : Exception
    {
        public RestaurantException(string message) :
            base(message)
        {
           
        }
    }
}
