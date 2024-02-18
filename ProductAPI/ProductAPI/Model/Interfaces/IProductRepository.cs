namespace ProductAPI.Model.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Create(Product produto);
        Product Update(Product produto);
        Product Disable(int id);
        Product Enable(int id);
    }
}