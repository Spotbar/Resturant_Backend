using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.DTO;
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
        public  IEnumerable<RestaurantDTO> GetAllRestaurantAsync()
        {
            var restaurants =  _repository.GetRestaurantsAsync().Result;
            foreach (var item in restaurants)
            {

                yield return (RestaurantDTO)item;
            }
           // return restaurants;
        }
        public async Task<RestaurantDTO?> Get_RestaurantByIdAsync(string RestaurantId)
        {
            RestaurantDTO restaurant = await _repository.Get_RestaurantByIdAsync(Guid.Parse( RestaurantId));
            return restaurant;
        }
        public async Task<RestaurantDTO?> Get_RestaurantByNameAsync(string RestaurantName)
        {
            RestaurantDTO restaurant = await _repository.Get_RestaurantByname(RestaurantName);
            return restaurant;
        }

        public async Task CreateRestaurantAsync(RestaurantDTO restaurant)
        {
            var res = _restaurantFactory.CreateRestaurant(restaurant.Name, restaurant.Tel, restaurant.OpratorName, restaurant.Mobile, restaurant.Address);
            await _repository.AddRestaurantAsync(res);
            await _repository.SaveChangesAsync();
        }



    }
}
