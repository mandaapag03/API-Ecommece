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

        public async Task<Category> Create(Category category)
        {
            try
            {
                if (await _context.Categories.AsNoTracking().Where(c => c.Nome == category.Nome).AnyAsync())
                {
                    throw new Exception("Essa categoria já está registrada");
                }

                await _context.Categories.AddAsync(category);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            int CategoryId = await _context.Categories.MaxAsync(c => c.Id);
            return await GetById(CategoryId);
        }

        public async Task<bool> Delete(int id)
        {
            var category = await GetById(id);

            var productsWithCategories = await _context.Products
                .AsNoTracking()
                .Where(c => c.CategoriaId == category.Id)
                .ToListAsync();

            var subCategory = await _context.Categories
                .AsNoTracking()
                .Where(c => c.IdSubCategoria == category.Id)
                .ToListAsync();

            if (productsWithCategories.Count != 0 || subCategory.Count != 0)
                throw new Exception("Há produtos atrelados a essa categoria ou subcategorias dependentes, ela não pode ser excluída");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Category>?> GetAll()
        {
            return await _context.Categories
                .AsNoTracking()
                .Include(c => c.SubCategoria)
                .OrderBy(c => c.Id)
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories
                .Include(c => c.SubCategoria)
                .FirstOrDefaultAsync(c => c.Id == id);

            return NullOrEmptyVariable<Category>.ThrowIfNull(category, "Categoria não existe");
        }

        public async Task<List<Category>?> GetSubCategoriesById(int id)
        {
            var subCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            NullOrEmptyVariable<Category>.ThrowIfNull(subCategory, "Categoria não existe");
            
            return await _context.Categories
                .Where(c => c.IdSubCategoria == id)
                .ToListAsync();
        }
    }
}
