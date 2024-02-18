using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Model;
using ProductAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace ProductAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository()
        {
            _context = new DatabaseContext();
        }

        public Category Create(Category category)
        {
            try
            {
                if (_context.Categories.AsNoTracking().Where(c => c.Nome == category.Nome).Any())
                {
                    throw new Exception("Essa categoria já está registrada");
                }

                _context.Categories.Add(category);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            int CategoryId = _context.Categories.Max(c => c.Id);
            return GetById(CategoryId);
        }

        public bool Delete(int id)
        {
            var category = GetById(id);

            var productsWithCategories = _context.Products
                .AsNoTracking()
                .Where(c => c.CategoriaId == category.Id)
                .ToList();

            var subCategory = _context.Categories
                .AsNoTracking()
                .Where(c => c.IdSubCategoria == category.Id)
                .ToList();

            if (productsWithCategories.Count != 0 || subCategory.Count != 0)
                throw new Exception("Há produtos atrelados a essa categoria ou subcategorias dependentes, ela não pode ser excluída");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return true;
        }

        public List<Category>? GetAll()
        {
            return _context.Categories
                .AsNoTracking()
                .Include(c => c.SubCategoria)
                .OrderBy(c => c.Id)
                .ToList();
        }

        public Category GetById(int id)
        {
            var category = _context.Categories
                .Include(c => c.SubCategoria)
                .FirstOrDefault(c => c.Id == id);

            return NullOrEmptyVariable<Category>.ThrowIfNull(category, "Categoria não existe");
        }

        public List<Category>? GetSubCategoriesById(int id)
        {
            var subCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            NullOrEmptyVariable<Category>.ThrowIfNull(subCategory, "Categoria não existe");
            
            return _context.Categories
                .Where(c => c.IdSubCategoria == id)
                .ToList();
        }
    }
}
