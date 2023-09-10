using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;

namespace OhMyDogAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        DatabaseContext _context;
        public ProdutoRepository() 
        {
            _context = new DatabaseContext();
        }
        public List<Produto> GetAllProducts()
        {
            return _context.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .ToList();
        }

        public Produto GetById(int id)
        {
            var result = _context.Produtos
                .Include(p => p.Categoria)
                .Include(c => c.Categoria.SubCategoria)
                .FirstOrDefault(p => p.Id == id);

            if (result == null) { throw new Exception("Produto não encontrado"); }
            return result;
        }

        public Produto Create(Produto produto)
        {
            throw new NotImplementedException();
        }
        public Produto Update(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto Disable(int id)
        {
            throw new NotImplementedException();
        }


    }
}
