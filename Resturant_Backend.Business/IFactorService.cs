using Resturant_Backend.Domain.DTO;

namespace Resturant_Backend.Business
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllFactorAsync();
        Task<OrderDTO?> Get_FactorByIdAsync(string OrderId);
        Task<OrderDTO?> Get_FactorByFactorNumberAsync(string OrderNumber);

        Task CreateOrderAsync(OrderDTO Factor);

        Task UpdateOrderAsync(OrderDTO Factor);
    }
}
