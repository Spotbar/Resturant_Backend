using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace Resturant_Backend.Domain.Entities
{
    public class DateCredit : Base
    {

        [Required]
        public required string Year { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public bool IsEnable { get; set; }


        // public virtual ICollection<FactorDetail> FactorDetails { get; set; }

    }
}
