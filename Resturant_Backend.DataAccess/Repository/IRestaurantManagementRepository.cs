using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public interface IRestaurantManagementRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant?> Get_RestaurantByIdAsync(Guid RestaurantId);

        Restaurant? Get_RestaurantById(Guid RestaurantId);
        Task<Restaurant?> Get_RestaurantByname(string RestaurantName);

        List<Restaurant> GetRestaurants(params Guid[] RestaurantIds);

        Task<List<Restaurant>> GetRestaurantsAsync(params Guid[] RestaurantIds);

        void AddRestaurant(Restaurant restaurant);

        Task SaveChangesAsync();
    }
}
