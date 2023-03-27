using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Backend.Domain.Entities
{
    public class User : Base
    {
        [Required]
        public required string Name { get; set; }

       // [Required]
        public string? Post { get; set; }

        [Required]
        public required string NationalCode { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public bool IsEnable { get; set; }


        [Required]
        public DateTimeOffset JoinDate { get; set; }


    }
}