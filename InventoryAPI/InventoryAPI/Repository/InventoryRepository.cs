using InventoryAPI.Communication;
using InventoryAPI.Data;
using InventoryAPI.Model;
using InventoryAPI.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using VerifyNullablesObjects;

namespace InventoryAPI.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly ProductCommunication _productCommunication;
        public InventoryRepository(IHttpClientFactory httpClientFactory)
        {
            _context = new DatabaseContext();
            _productCommunication = new ProductCommunication(httpClientFactory);
        }

        public async Task<Inventory> Add(Inventory inventory)
        {
            try
            {
                await _context.Inventories.AddAsync(inventory);
                _context.SaveChanges();

                return await Get(inventory.ProductId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Inventory> Delete(int productId)
        {
            try
            {
                var inventory = await Get(productId);

                if(inventory.Quantity != 0) { throw new Exception("Esse produto ainda tem quantidades no estoque."); }

                _context.Inventories.Remove(inventory);
                _context.SaveChanges();

                return inventory;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Inventory> Get(int productId)
        {
            return NullOrEmptyVariable<Inventory>.ThrowIfNull( 
                await _context.Inventories.FirstOrDefaultAsync(x => x.ProductId == productId), "Produto não encontrado no estoque.");
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _context.Inventories.AsNoTracking().ToListAsync();
        }

        public async Task<Inventory> UpdateQuantity(Inventory inventory)
        {
            try
            {
                await Get(inventory.ProductId);

                //_context.Entry<Inventory>(inventory).State = EntityState.Detached;
                _context.Inventories.Update(inventory);
                _context.SaveChanges();

                if(inventory.Quantity == 0)
                {
                   //var product = await _productCommunication.DisableProduct(inventory.ProductId);
                   // NullOrEmptyVariable<Product>.ThrowIfNull(product, "Erro ao desabilitar esse produto");
                }
                return inventory;
            }
            catch
            {
                throw;
            }
        }
    }
}
