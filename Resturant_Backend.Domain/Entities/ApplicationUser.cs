using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace Resturant_Backend.Domain.Entities
{
    // Add profile data for application users by adding properties to the Resturant_BackendAPIUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public  string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        // [Required]
        [MaxLength(50)]
        public string? Post { get; set; }

        [Required]
        [MaxLength(10)]
        public  string NationalCode { get; set; }

       
    }

}


