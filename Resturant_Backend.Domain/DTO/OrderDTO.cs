using Resturant_Backend.Domain.BaseModels;
using Resturant_Backend.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Resturant_Backend.Domain.DTO
{
    public class OrderDTO
    {
        public string? Id { get; set; }
        public  string? Name { get; set; }
        public long Cost { get; set; } 
        public bool IsShared { get; set; } 
        public bool IsAccept { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        public string? RestaurantId { get; set; }
        public virtual Minimal_RestaurantDTO? Restaurant { get; set; }

        public static implicit operator OrderDTO(Order? order)
        {
            if(order is null) return new OrderDTO();
            return new() { 
                Id= order.Id.ToString(),
                RestaurantId = order.RestaurantId.ToString(),
                Name = order.Name,
                Cost = order.Cost,
                IsShared = order.IsShared,
                IsAccept = order.IsAccept,
                OrderDate = order.OrderDate,
                Restaurant = order.Restaurant,
               
            };
        }
       
    }


}
