using Microsoft.EntityFrameworkCore;
using Resturant_Backend.Domain.DbContexts;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public class RestaurantManagementRepository : IRestaurantManagementRepository
    {
        private readonly ApplicationDBContext _context;

        public RestaurantManagementRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            return await _context.Restaurants
                .ToListAsync();
        }

        public async Task<Restaurant?> Get_RestaurantByIdAsync(Guid RestaurantId)
        {
            return await _context.Restaurants
                .FirstOrDefaultAsync(e => e.Id == RestaurantId);
        }
     
        public Restaurant? Get_RestaurantById(Guid RestaurantId)
        {
            return _context.Restaurants
                .FirstOrDefault(e => e.Id == RestaurantId);
        }
        public async Task<Restaurant?> Get_RestaurantByname(string restaurantName)
        {
            return await _context.Restaurants
                .FirstOrDefaultAsync(e => e.Name.Equals(restaurantName));
        }


        public List<Restaurant> GetRestaurants(params Guid[] RestaurantIds)
        {
            List<Restaurant> restaurants = new();
            foreach (var restaurantid in RestaurantIds)
            {
                var restaurant = Get_RestaurantById(restaurantid);
                if (restaurant != null)
                {
                    restaurants.Add(restaurant);
                }
            }
            return restaurants;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync(params Guid[] RestaurantIds)
        {
            List<Restaurant> restaurants = new();
            foreach (var restaurantid in RestaurantIds)
            {
                var restaurant = await Get_RestaurantByIdAsync(restaurantid);
                if (restaurant != null)
                {
                    restaurants.Add(restaurant);
                }
            }
            return restaurants;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
