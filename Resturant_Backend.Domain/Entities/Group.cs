using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Backend.Domain.Entities
{
    public class Group : Base
    {

        [Required]
        public required string Name { get; set; }

     

    }
}
