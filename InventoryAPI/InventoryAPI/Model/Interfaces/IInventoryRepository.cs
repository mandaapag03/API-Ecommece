namespace InventoryAPI.Model.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAll();
        Task<Inventory> Get(int productId);
        Task<Inventory> Add(Inventory inventory);
        Task<Inventory> UpdateQuantity(Inventory inventory);
        // Task<Inventory> Delete(int productId);
    }
}
