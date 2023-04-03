using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Backend.Domain.Entities
{
    public class Wallet : Base
    {
        [Required]
        public  string Username { get; set; }
        [Required]
        public long Amonut { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }


        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser? User { get; set; }


        [Required]
        public Guid DateCreditId { get; set; }

        [ForeignKey(nameof(DateCreditId))]
        public virtual DateCredit? DateCredit { get; set; }

    }
}