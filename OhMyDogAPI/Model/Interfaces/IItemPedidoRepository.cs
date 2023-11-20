namespace OhMyDogAPI.Model.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<List<ItemPedido>> GetAll(int idPedido);
        Task<ItemPedido> GetItemWithPedidoId(int idPedido, int idItem);
        Task<ItemPedido> GetItem(int idItem);
        Task<ItemPedido> Insert(ItemPedido itemPedido);
    }
}
