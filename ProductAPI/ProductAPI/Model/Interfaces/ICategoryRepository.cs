namespace ProductAPI.Model.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>?> GetAll();
        Task<Category> GetById(int id);
        Task<List<Category>?> GetSubCategoriesById(int id);
        Task<Category> Create(Category category);
        Task<bool> Delete(int id);
    }
}
