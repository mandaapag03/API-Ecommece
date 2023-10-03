using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

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
                if (_context.Categorias.AsNoTracking().Where(c => c.Nome == categoria.Nome).Any())
                {
                    throw new Exception("Essa categoria já está registrada");
                }

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

        public bool Delete(int id)
        {
            var categoria = GetById(id);

            var produtosComCategoria = _context.Produtos
                .AsNoTracking()
                .Where(c => c.CategoriaId == categoria.Id)
                .ToList();

            var subcategorias = _context.Categorias
                .AsNoTracking()
                .Where(c => c.IdSubCategoria == categoria.Id)
                .ToList();

            if (produtosComCategoria.Count != 0 || subcategorias.Count != 0)
                throw new Exception("Há produtos atrelados a essa categoria ou subcategorias dependentes, ela não pode ser excluída");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return true;
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

            return NullOrEmptyVariable<Categoria>.ThrowIfNull(categoria, "Categoria não existe");
        }

        public List<Categoria>? GetSubcategoriasById(int id)
        {
            var sobCategoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            NullOrEmptyVariable<Categoria>.ThrowIfNull(sobCategoria, "Categoria não existe");
            
            return _context.Categorias
                .Where(c => c.IdSubCategoria == id)
                .ToList();
        }
    }
}
