namespace OrderAPI.Model.Interfaces
{
    public interface IShippingRepository
    {
        Task<List<Shipping>> GetAll();
        Task<Shipping> Get(int id);
    }
}
