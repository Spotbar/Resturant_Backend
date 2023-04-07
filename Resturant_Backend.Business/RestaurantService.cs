using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.Business
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantManagementRepository _repository;
        private readonly RestaurantFactory _restaurantFactory;


        public RestaurantService(IRestaurantManagementRepository repository,
            RestaurantFactory restaurantFactory)
        {
            _repository = repository;
            _restaurantFactory = restaurantFactory;
        }
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync()
        {
            var restaurants = await _repository.GetRestaurantsAsync();
            return restaurants;
        }
        public async Task<Restaurant?> Get_RestaurantByIdAsync(string RestaurantId)
        {
            var restaurant = await _repository.Get_RestaurantByIdAsync(Guid.Parse( RestaurantId));
            return restaurant;
        }
        public async Task<Restaurant?> Get_RestaurantByNameAsync(string RestaurantName)
        {
            var restaurant = await _repository.Get_RestaurantByname(RestaurantName);
            return restaurant;
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            var res = _restaurantFactory.CreateRestaurant(restaurant.Name, restaurant.Tel, restaurant.OpratorName, restaurant.Mobile, restaurant.Address);
            _repository.AddRestaurant(res);
            await _repository.SaveChangesAsync();
        }



    }
}
