using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly DatabaseContext _context;
        public OrderStatusRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<OrderStatus>> GetAll()
        {
            return await _context.OrderStatus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderStatus> Get(int id)
        {
            return NullOrEmptyVariable<OrderStatus>.ThrowIfNull(
                await _context.OrderStatus
                .FirstOrDefaultAsync(x => x.Id == id)
                , "Status de pedido não encontrado");
        }
    }
}
