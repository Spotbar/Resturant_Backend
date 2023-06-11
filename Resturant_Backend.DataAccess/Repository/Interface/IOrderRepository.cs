using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> Get_OrderByIdAsync(Guid OrderId);

        Order? Get_OrderById(Guid OrderId);
     

        List<Order> GetOrders(params Guid[] OrderIds);

        Task<List<Order>> GetOrdersAsync(params Guid[] OrderIds);

        Task AddOrderAsync(Order Order);
        void UpdateOrder(Order Order);


        Task SaveChangesAsync();
    }
}
