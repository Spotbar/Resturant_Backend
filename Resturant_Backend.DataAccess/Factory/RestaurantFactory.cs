using Resturant_Backend.Domain.Entities;
using System.Text.RegularExpressions;

namespace Resturant_Backend.DataAccess.Factory
{
    public class RestaurantFactory
    {
        /// <summary>
        /// Create an Restaurant
        /// </summary>

        public virtual Restaurant CreateRestaurant(string name,
      string tel,
      string? opratorName = null,
      string? mobile = null,
      string? address = null)
        {
            string phoneNummberPattern = @"^0[1-9]\d{9}$";
            Regex rg = new Regex(phoneNummberPattern);

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
            if (!rg.IsMatch(tel))
            {
                throw new ArgumentException($"'{nameof(tel)}' cannot be The length  less than 11.",
                    nameof(tel));
            }

            if (!string.IsNullOrEmpty(mobile))
            {
                if (!rg.IsMatch(mobile))
                {
                    throw new ArgumentException($"'{nameof(mobile)}' cannot be null or empty.",
                        nameof(mobile));
                }
               
            }
            return new Restaurant(name, tel, opratorName, mobile, address);
        }
    }
}
