using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DatabaseContext _context;

        public OrderItemRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<OrderItem> GetItemByOrderId(int orderId, int orderItemId)
        {
            return NullOrEmptyVariable<OrderItem>.ThrowIfNull( 
                await _context.OrderItems
                .Where(x => x.PedidoId == orderId)
                .FirstOrDefaultAsync(x => x.Id == orderId)
                );
        }

        public async Task<List<OrderItem>> GetAll(int orderId)
        {
            return await _context.OrderItems
                .Where(x => x.PedidoId == orderId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderItem> Get(int orderItemId)
        {
            return NullOrEmptyVariable<OrderItem>.ThrowIfNull(
                await _context.OrderItems
                .FirstOrDefaultAsync(x => x.Id == orderItemId)
                );
        }

        public async Task<OrderItem> Insert(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            _context.SaveChanges();

            var orderItemId = _context.OrderItems.Max(x => x.Id);
            return await Get(orderItemId);
        }
    }
}
