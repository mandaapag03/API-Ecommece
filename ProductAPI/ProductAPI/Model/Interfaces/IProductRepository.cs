namespace ProductAPI.Model.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Create(Product produto);
        Task<Product> Update(Product produto);
        Task<Product> Disable(int id);
        Task<Product> Enable(int id);
    }
}