using Microsoft.IdentityModel.Tokens;
using Resturant_Backend.Domain.Entities;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Resturant_Backend.DataAccess.Factory
{
    public class RestaurantFactory
    {
        /// <summary>
        /// Create an Restaurant
        /// </summary>
        Regex phoneNummberPattern;
        Regex MobileNummberPattern;
        public RestaurantFactory()
        {
            phoneNummberPattern = new Regex(@"^0[1-9]\d{9}$") ;
            MobileNummberPattern = new Regex(@"^0([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}") ;
        }
        public virtual Restaurant CreateRestaurant(string name,
      string tel,
      string? opratorName = null,
      string? mobile = null,
      string? address = null)
        {

           

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.",
                    nameof(name));
            }

            if (string.IsNullOrEmpty(tel))
            {
                throw new ArgumentException($"'{nameof(tel)}' cannot be null or empty.",
                    nameof(tel));
            }

            if (!phoneNummberPattern.IsMatch(tel))
            {
                throw new ArgumentException($"'{nameof(tel)}' cannot be The length  less than 11.",
                    nameof(tel));
            }

            if (!string.IsNullOrEmpty(mobile))
            {
                if (!MobileNummberPattern.IsMatch(mobile))
                {
                    throw new ArgumentException($"'{nameof(mobile)}' cannot be null or empty.",
                        nameof(mobile));
                }
               
            }
            if (!string.IsNullOrEmpty(address))
            {
                if (address.Length>=250)
                {
                    throw new ArgumentException($"'{nameof(address)}' cannot be Larger than 250.",
                        nameof(address));
                }

            }

            return new Restaurant(Guid.Empty,name, tel, opratorName, mobile, address);
        }

        public virtual Restaurant UpdateRestaurant(
            Guid id,
            string name,
string tel,
string? opratorName = null,
string? mobile = null,
string? address = null)
        {   


            if (Guid.Empty==(id) )
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.",
                    nameof(id));
            }

            if (string.IsNullOrEmpty(tel))
            {
                throw new ArgumentException($"'{nameof(tel)}' cannot be null or empty.",
                    nameof(tel));
            }
            if (!phoneNummberPattern.IsMatch(tel))
            {
                throw new ArgumentException($"'{nameof(tel)}' cannot be The length  less than 11.",
                    nameof(tel));
            }

            if (!string.IsNullOrEmpty(mobile))
            {
                if (!MobileNummberPattern.IsMatch(mobile))
                {
                    throw new ArgumentException($"'{nameof(mobile)}' cannot be null or empty.",
                        nameof(mobile));
                }

            }
            if (!string.IsNullOrEmpty(address))
            {
                if (address.Length >= 250)
                {
                    throw new ArgumentException($"'{nameof(address)}' cannot be Larger than 250.",
                        nameof(address));
                }

            }
            return new Restaurant(id,name, tel, opratorName, mobile, address);
        }
    }
}
