using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Model;
using ProductAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository() 
        {
            _context = new DatabaseContext();
        }
        public List<Product> GetAll()
        {
            return _context.Products
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .ToList();
        }

        public Product GetById(int id)
        {
            var result = _context.Products
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .FirstOrDefault(p => p.Id == id);

            return NullOrEmptyVariable<Product>.ThrowIfNull(result, "Produto não encontrado");
        }

        public Product Create(Product produto)
        {
            _context.Products.Add(produto);
            _context.SaveChanges();

            var result = _context.Products
                .Include(p => p.Categoria)
                .FirstOrDefault(p => p.Nome == produto.Nome);

            return NullOrEmptyVariable<Product>.ThrowIfNull(result, "Não foi possível cadastrar seu produto, tente mais tarde.");
        }
        public Product Update(Product produto)
        {
            var oldProduct = _context.Products.FirstOrDefault(p => p.Id == produto.Id);
            if (oldProduct == null)
                throw new Exception("Produto não encontrado");

            oldProduct.Nome = produto.Nome;
            oldProduct.PrecoUnitario = produto.PrecoUnitario;
            oldProduct.Descricao = produto.Descricao;
            oldProduct.CategoriaId = produto.CategoriaId;
            oldProduct.Foto = produto.Foto;
            
            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return GetById(oldProduct.Id);
        }

        public Product Disable(int id)
        {
            var oldProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            NullOrEmptyVariable<Product>.ThrowIfNull(oldProduct, "Produto não encontrado");

            oldProduct.IsActive = false;

            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return GetById(id);
        }

        public Product Enable(int id)
        {
            var oldProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            NullOrEmptyVariable<Product>.ThrowIfNull(oldProduct, "Produto não encontrado");

            oldProduct.IsActive = true;

            _context.Products.Update(oldProduct);
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
