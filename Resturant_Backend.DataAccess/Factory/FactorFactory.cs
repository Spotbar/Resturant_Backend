using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Factory
{
    public class FactorFactory
    {
        /// <summary>
        /// Create an Restaurant
        /// </summary>

        public FactorFactory()
        {

        }
        public virtual Factor CreateFactor(string factorNumber,
      DateTimeOffset factorDate,
      long deliveryCost,
      long factorAmount,
      bool isClosed,
      bool isDeliveryByCompanyPaid,
      string restaurantId)
        {



            if (string.IsNullOrEmpty(factorNumber))
            {
                throw new ArgumentException($"'{nameof(factorNumber)}' cannot be null or empty.",
                    nameof(factorNumber));
            }

            if (string.IsNullOrEmpty(restaurantId))
            {
                throw new ArgumentException($"'{nameof(restaurantId)}' cannot be null or empty.",
                    nameof(restaurantId));
            }

            if (deliveryCost < 0)
            {
                throw new ArgumentException($"'{nameof(deliveryCost)}' Invalid.",
                    nameof(deliveryCost));
            }
            if (factorAmount < 0)
            {
                throw new ArgumentException($"'{nameof(factorAmount)}' Invalid.",
                    nameof(factorAmount));
            }

            return new Factor(Guid.Empty, factorNumber, factorDate, deliveryCost, factorAmount, isClosed, isDeliveryByCompanyPaid, restaurantId);
        }

        public virtual Factor UpdateFactor(
          string Id,
          string factorNumber,
          DateTimeOffset factorDate,
          long deliveryCost,
          long factorAmount,
          bool isClosed,
          bool isDeliveryByCompanyPaid,
          string restaurantId)
        {


            if (string.IsNullOrEmpty(factorNumber))
            {
                throw new ArgumentException($"'{nameof(factorNumber)}' cannot be null or empty.",
                    nameof(factorNumber));
            }

            if (string.IsNullOrEmpty(restaurantId))
            {
                throw new ArgumentException($"'{nameof(restaurantId)}' cannot be null or empty.",
                    nameof(restaurantId));
            }

            if (deliveryCost < 0)
            {
                throw new ArgumentException($"'{nameof(deliveryCost)}' Invalid.",
                    nameof(deliveryCost));
            }
            if (factorAmount < 0)
            {
                throw new ArgumentException($"'{nameof(factorAmount)}' Invalid.",
                    nameof(factorAmount));
            }
            return new Factor(Guid.Empty, factorNumber, factorDate, deliveryCost, factorAmount, isClosed, isDeliveryByCompanyPaid, restaurantId);
        }
    }
}
