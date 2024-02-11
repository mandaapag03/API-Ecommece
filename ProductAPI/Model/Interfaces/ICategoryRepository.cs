namespace ProductAPI.Model.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category>? GetAll();
        Category GetById(int id);
        List<Category>? GetSubCategoriesById(int id);
        Category Create(Category category);
        bool Delete(int id);
    }
}
