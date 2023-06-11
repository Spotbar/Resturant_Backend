using Microsoft.EntityFrameworkCore;
using Resturant_Backend.Domain.DbContexts;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(x=>x.Restaurant)
                .ToListAsync();
        }

        public async Task<Order?> Get_OrderByIdAsync(Guid OrderId)
        {
            return await _context.Orders
                 .Include(x => x.Restaurant)
                .FirstOrDefaultAsync(e => e.Id == OrderId);
        }
     
        public Order? Get_OrderById(Guid OrderId)
        {
            return _context.Orders
                 .Include(x => x.Restaurant)
                .FirstOrDefault(e => e.Id == OrderId);
        }
     


        public List<Order> GetOrders(params Guid[] FactorIds)
        {
            List<Order> Factors = new();
            foreach (var Factorid in FactorIds)
            {
                var Factor = Get_OrderById(Factorid);
                if (Factor != null)
                {
                    Factors.Add(Factor);
                }
            }
            return Factors;
        }

        public async Task<List<Order>> GetOrdersAsync(params Guid[] orderIds)
        {
            List<Order> Orders = new();
            foreach (var Factorid in orderIds)
            {
                var Factor = await Get_OrderByIdAsync(Factorid);
                if (Factor != null)
                {
                    Orders.Add(Factor);
                }
            }
            return Orders;
        }

        public async Task AddOrderAsync(Order Order)
        {
             await _context.Orders.AddAsync(Order);
        }
        public void UpdateOrder(Order Order)
        {
             _context.Orders.Update(Order);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
