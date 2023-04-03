using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Backend.Domain.Entities
{
    public class Order : Base
    {

        [Required]
        public  string Name { get; set; }
        [Required]
        public long Cost { get; set; }
      
        public bool IsShared { get; set; }
        public bool IsAccept { get; set; }

        [Required]
        public Guid FactorId { get; set; }

        [ForeignKey(nameof(FactorId))]
        public virtual Factor? Factor { get; set; }

    }
}
