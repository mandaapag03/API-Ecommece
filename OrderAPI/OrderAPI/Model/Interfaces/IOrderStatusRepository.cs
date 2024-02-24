namespace OrderAPI.Model.Interfaces
{
    public interface IOrderStatusRepository
    {
        Task<List<OrderStatus>> GetAll();
        Task<OrderStatus> Get(int id);
    }
}
