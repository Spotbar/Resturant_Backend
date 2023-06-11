using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Factory
{
    public class OrderFactory
    {
        /// <summary>
        /// Create an Restaurant
        /// </summary>

        public OrderFactory()
        {

        }
        public virtual Order CreateOrder(string name,
              long cost,
              bool isShared,
              bool isAccept,
              DateTimeOffset orderDate,
              string restaurantId)
        {



            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.",
                    nameof(name));
            }
            if (string.IsNullOrEmpty(restaurantId))
            {
                throw new ArgumentException($"'{nameof(restaurantId)}' cannot be null or empty.",
                    nameof(restaurantId));
            }
            if (cost<0)
            {
                throw new ArgumentException($"'{nameof(cost)}' cannot be less 0.",
                    nameof(cost));
            }

           
           
          
            return new Order(Guid.Empty, name, cost, isShared, isAccept, orderDate, restaurantId);
        }

        public virtual Order UpdateOrder(
          string Id,
      string name,
              long cost,
              bool isShared,
              bool isAccept,
              DateTimeOffset orderDate,
              string restaurantId)
        {


            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.",
                    nameof(name));
            }
            if (string.IsNullOrEmpty(restaurantId))
            {
                throw new ArgumentException($"'{nameof(restaurantId)}' cannot be null or empty.",
                    nameof(restaurantId));
            }
            if (cost < 0)
            {
                throw new ArgumentException($"'{nameof(cost)}' cannot be less 0.",
                    nameof(cost));
            }
            return new Order(Guid.Parse(Id), name, cost, isShared, isAccept, orderDate, restaurantId);
        }
    }
}
