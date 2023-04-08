using Resturant_Backend.Domain.Entities;
using System.Text.RegularExpressions;

namespace Resturant_Backend.DataAccess.Factory
{
    public class UserFactory
    {
        /// <summary>
        /// Create an Restaurant
        /// </summary>

        public virtual ApplicationUser CreateUser(string name, string lastName,
      string nationalCode,
      string phoneNumber ,
      string? post = null)
        {
            string phoneNummberPattern = @"^0[1-9]\d{9}$";
            Regex rg = new Regex(phoneNummberPattern);

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.",
                    nameof(name));
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.",
                    nameof(lastName));
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be null or empty.",
                    nameof(phoneNumber));
            }
            else
            {
                if (!rg.IsMatch(phoneNumber))
                {
                    throw new ArgumentException($"'{nameof(phoneNumber)}' cannot be The length  less than 11.",
                        nameof(phoneNumber));
                }

            }


            return new ApplicationUser() { Name = name, LastName = lastName, NationalCode = nationalCode,Post= post, PhoneNumber= phoneNumber };
        }
    }
}
