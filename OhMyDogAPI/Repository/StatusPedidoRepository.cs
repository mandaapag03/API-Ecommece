using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class StatusPedidoRepository : IStatusPedidoRepository
    {
        private readonly DatabaseContext _context;
        public StatusPedidoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<StatusPedido>> GetAll()
        {
            return await _context.StatusPedidos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StatusPedido> GetStatusPedido(int id)
        {
            return NullOrEmptyVariable<StatusPedido>.ThrowIfNull(
                await _context.StatusPedidos
                .FirstOrDefaultAsync(x => x.Id == id)
                , "Status de pedido não encontrado");
        }
    }
}
