namespace OrderAPI.Model.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAll(int orderId);
        Task<OrderItem> GetItemByOrderId(int orderId, int orderItemId);
        Task<OrderItem> Get(int orderItemId);
        Task<OrderItem> Insert(OrderItem orderItem);
    }
}
