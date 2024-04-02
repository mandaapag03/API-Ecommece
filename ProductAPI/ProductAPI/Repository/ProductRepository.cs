using Microsoft.EntityFrameworkCore;
using ProductAPI.Communication;
using ProductAPI.Data;
using ProductAPI.Model;
using ProductAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly InventoryCommunication _inventoryCommunication;
        public ProductRepository(IHttpClientFactory httpClientFactory) 
        {
            _context = new DatabaseContext();
            _inventoryCommunication = new InventoryCommunication(httpClientFactory);
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _context.Products
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            return NullOrEmptyVariable<Product>.ThrowIfNull(result, "Produto não encontrado");
        }

        public async Task<Product> Create(Product produto)
        {
            try
            {
                await _context.Products.AddAsync(produto);
                _context.SaveChanges();

                var result = await _context.Products
                    .Include(p => p.Categoria)
                    .FirstOrDefaultAsync(p => p.Nome == produto.Nome);

                NullOrEmptyVariable<Product>.ThrowIfNull(result, "Não foi possível cadastrar seu produto, tente mais tarde.");

                //var inventory = await _inventoryCommunication.AddProductToInventory(result.Id);
                //NullOrEmptyVariable<Inventory>.ThrowIfNull(inventory, "Não foi possível cadastrar seu produto no inventário");

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Product> Update(Product produto)
        {
            var oldProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == produto.Id);

            NullOrEmptyVariable<Product>.ThrowIfNull(oldProduct, "Produto não encontrado");

            oldProduct.Nome = produto.Nome;
            oldProduct.PrecoUnitario = produto.PrecoUnitario;
            oldProduct.Descricao = produto.Descricao;
            oldProduct.CategoriaId = produto.CategoriaId;
            oldProduct.Foto = produto.Foto;
            
            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return await GetById(oldProduct.Id);
        }

        public async Task<Product> Disable(int id)
        {
            var oldProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            NullOrEmptyVariable<Product>.ThrowIfNull(oldProduct, "Produto não encontrado");

            oldProduct.IsActive = false;

            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return await GetById(id);
        }

        public async Task<Product> Enable(int id)
        {
            var oldProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            NullOrEmptyVariable<Product>.ThrowIfNull(oldProduct, "Produto não encontrado");

            oldProduct.IsActive = true;

            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return await GetById(id);
        }
    }
}
