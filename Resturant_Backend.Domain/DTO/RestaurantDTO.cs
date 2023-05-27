using Resturant_Backend.Domain.Entities;


namespace Resturant_Backend.Domain.DTO
{
    public class RestaurantDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }

        public string? OpratorName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }

        public static implicit operator RestaurantDTO(Restaurant? restaurant)
        {
            if (restaurant is null) return new RestaurantDTO();
            return new()
            {
                Id = restaurant.Id.ToString(),
                Name = restaurant.Name,
                Address = restaurant.Address,
                Mobile = restaurant.Mobile,
                OpratorName = restaurant.OpratorName,
                Tel = restaurant.Tel
            };
        }

    }
    public class Minimal_RestaurantDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Minimal_RestaurantDTO(Restaurant? restaurant)
        {
            if (restaurant is null) return new Minimal_RestaurantDTO();
            return new()
            {
                Id = restaurant.Id.ToString(),
                Name = restaurant.Name,
               
            };
        }


    }
}
