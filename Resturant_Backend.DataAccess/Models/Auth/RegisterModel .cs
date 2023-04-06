using Resturant_Backend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Backend.DataAccess.Models.Auth
{
    public class RegisterModel
    {
        // [Required(ErrorMessage = "User Name is required")]
        // public string Username { get; set; }
        [Required]
        public string NationalCode { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }




        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }


        public string? Post { get; set; }

    }
}
