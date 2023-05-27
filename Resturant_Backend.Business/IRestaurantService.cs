using Resturant_Backend.Domain.DTO;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.Business
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantDTO> GetAllRestaurantAsync();
        Task<RestaurantDTO?> Get_RestaurantByIdAsync(string RestaurantId);
        Task<RestaurantDTO?> Get_RestaurantByNameAsync(string RestaurantName);

        Task CreateRestaurantAsync(RestaurantDTO restaurant);

        Task UpdateRestaurantAsync(RestaurantDTO restaurant);
    }
}
