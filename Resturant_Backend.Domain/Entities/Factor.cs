using Resturant_Backend.Domain.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;

namespace Resturant_Backend.Domain.Entities
{
    public class Factor : Base
    {

       
        public string? FactorNumber { get; set; }

        public DateTimeOffset FactorDate { get; set; }
        [Required]
        
        public long DeliveryCost { get; set; }
        [Required]
        public long FactorAmount { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeliveryByCompanyPaid { get; set; }

        [Required]
        public Guid RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant? Restaurant { get; set; }

        public Factor()
        {
            
        }
        public Factor(Guid id, string factorNumber,
      DateTimeOffset factorDate,
      long deliveryCost,
      long factorAmount,
      bool isClosed,
      bool isDeliveryByCompanyPaid,
      string restaurantId) : base()
        {
            Id = id;
            FactorNumber = factorNumber;
            FactorDate = factorDate;
            DeliveryCost = deliveryCost;
            FactorAmount = factorAmount;
            IsClosed = isClosed;
            IsDeliveryByCompanyPaid = isDeliveryByCompanyPaid;
            RestaurantId = Guid.Parse( restaurantId);
        }
    }
}
