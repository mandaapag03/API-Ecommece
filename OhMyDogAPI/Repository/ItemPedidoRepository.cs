using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly DatabaseContext _context;

        public ItemPedidoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<ItemPedido> GetItemWithPedidoId(int idPedido, int idItem)
        {
            return NullOrEmptyVariable<ItemPedido>.ThrowIfNull( 
                await _context.ItensPedido
                .Where(x => x.PedidoId == idPedido)
                .FirstOrDefaultAsync(x => x.Id == idItem)
                );
        }

        public async Task<List<ItemPedido>> GetAll(int idPedido)
        {
            return await _context.ItensPedido
                .Where(x => x.PedidoId == idPedido)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ItemPedido> GetItem(int idItem)
        {
            return NullOrEmptyVariable<ItemPedido>.ThrowIfNull(
                await _context.ItensPedido
                .FirstOrDefaultAsync(x => x.Id == idItem)
                );
        }

        public async Task<ItemPedido> Insert(ItemPedido itemPedido)
        {
            await _context.ItensPedido.AddAsync(itemPedido);
            _context.SaveChanges();

            var itemId = _context.ItensPedido.Max(x => x.Id);
            return await GetItem(itemId);
        }
    }
}
