using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        private DatabaseContext _context;
        public ShippingRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<Shipping>> GetAll()
        {
            return await _context.Shipping.AsNoTracking().ToListAsync();
        }

        public async Task<Shipping> Get(int id)
        {
            var shipping = await _context.Shipping.FirstOrDefaultAsync(x => x.Id == id);
            return NullOrEmptyVariable<Shipping>.ThrowIfNull(shipping, "Forma de envio não encontrada");
        }
    }
}
