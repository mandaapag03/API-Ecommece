using OrderAPI.Model.DTO;

namespace OrderAPI.Model.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> Get(int id);
        Task<object> Create(NewOrder newOrder);
        Task<dynamic> Cancel(int id);
    }
}
