namespace OrderAPI.Model.Interfaces
{
    public interface ICartRepository
    {
        public Task<Cart?> Get(int userId);
        public Task<CartItem?> AddItem(CartItem item);
        public Task<bool> DeleteItem(CartItem item);
    }
}
