using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_Backend.Domain.Entities
{
    public class Factor : Base
    {

       
        public string? FactorNummber { get; set; }

        public DateTimeOffset FactorDate { get; set; }
        [Required]
        public long DeliveryCost { get; set; }
        [Required]
        public long FactorAmount { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeliveryByCompany { get; set; }

        [Required]
        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant? Restaurant { get; set; }

    }
}
