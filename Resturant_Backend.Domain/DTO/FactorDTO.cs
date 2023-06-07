using Resturant_Backend.Domain.BaseModels;
using Resturant_Backend.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Resturant_Backend.Domain.DTO
{
    public class FactorDTO
    {
        public string? Id { get; set; }
        public  string? FactorNumber { get; set; }
        public DateTimeOffset FactorDate { get; set; }

        public long DeliveryCost { get; set; }
        public long FactorAmount { get; set; }
        public bool IsClosed { get; set; }
        public bool IsDeliveryByCompanyPaid { get; set; }
        public string? RestaurantId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Minimal_RestaurantDTO? Restaurant { get; set; }

        public static implicit operator FactorDTO(Factor? fator)
        {
            if(fator is null) return new FactorDTO();
            return new() { 
                Id= fator.Id.ToString(),
                RestaurantId = fator.RestaurantId.ToString(),
                FactorNumber = fator.FactorNumber,
                FactorDate = fator.FactorDate,
                DeliveryCost = fator.DeliveryCost,
                FactorAmount = fator.FactorAmount,
                IsClosed = fator.IsClosed,
                IsDeliveryByCompanyPaid = fator.IsDeliveryByCompanyPaid,
                Restaurant =fator.Restaurant,
                Orders=fator.Orders
            };
        }
       
    }


}
