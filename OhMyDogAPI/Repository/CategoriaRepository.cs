using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;

namespace OhMyDogAPI.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        DatabaseContext _context;

        public CategoriaRepository()
        {
            _context = new DatabaseContext();
        }

        public Categoria Create(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            int idCategoria = _context.Categorias.Max(c => c.Id);
            return GetById(idCategoria);
        }

        public Categoria Delete(int id)
        {
            var categoria = GetById(id);

            var produtosComCategoria = _context.Produtos
                .AsNoTracking()
                .Where(c => c.CategoriaId == categoria.Id)
                .ToList();

            var subcategorias = _context.Categorias
                .AsNoTracking()
                .Where(c => c.IdSubCategoria != null)
                .ToList();

            if (produtosComCategoria.Count != 0 || subcategorias.Count != 0)
                throw new Exception("Há produtos atrelados a essa categoria ou subcategorias dependentes, ela não pode ser excluída");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public List<Categoria>? GetAllCategorias()
        {
            return _context.Categorias
                .AsNoTracking()
                .Include(c => c.SubCategoria)
                .OrderBy(c => c.Id)
                .ToList();
        }

        public Categoria GetById(int id)
        {
            var categoria = _context.Categorias
                .Include(c => c.SubCategoria)
                .FirstOrDefault(c => c.Id == id);

            return categoria == null ? throw new Exception("Categoria não existe") : categoria; 
        }
    }
}
