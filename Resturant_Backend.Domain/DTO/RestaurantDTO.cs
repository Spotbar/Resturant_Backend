using Resturant_Backend.Domain.BaseModels;
using Resturant_Backend.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Resturant_Backend.Domain.DTO
{
    public class RestaurantDTO 
    {
        public  string Name { get; set; }
        public  string Tel { get; set; }

        public string? OpratorName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
    
        public static implicit operator RestaurantDTO(Restaurant? restaurant)
        {
            if(restaurant is null) return new RestaurantDTO();
            return new() { 
                Name = restaurant.Name,
                Address = restaurant.Address,
                Mobile = restaurant.Mobile,
                OpratorName = restaurant.OpratorName,
                Tel = restaurant.Tel
            };
        }
       
    }
}
