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
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            var result = _context.Produtos
                .Include (p => p.Categoria)
                .FirstOrDefault(p => p.Nome == produto.Nome);
            if (result == null) { throw new Exception("Não foi possível cadastrar seu produto, tente mais tarde.");  }
            return result;
        }
        public Produto Update(Produto produto)
        {
            var oldProduto = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (oldProduto == null)
                throw new Exception("Produto não encontrado");

            oldProduto.Nome = produto.Nome;
            oldProduto.PrecoUnitario = produto.PrecoUnitario;
            oldProduto.Descricao = produto.Descricao;
            oldProduto.CategoriaId = produto.CategoriaId;
            oldProduto.Foto = produto.Foto;
            
            _context.Produtos.Update(oldProduto);
            _context.SaveChanges();

            return GetById(oldProduto.Id);
        }

        public Produto Disable(int id)
        {
            var oldProduto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (oldProduto == null)
                throw new Exception("Produto não encontrado");

            oldProduto.IsActive = false;

            _context.Produtos.Update(oldProduto);
            _context.SaveChanges();

            return GetById(id);
        }

        public Produto Enable(int id)
        {
            var oldProduto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (oldProduto == null)
                throw new Exception("Produto não encontrado");

            oldProduto.IsActive = true;

            _context.Produtos.Update(oldProduto);
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
