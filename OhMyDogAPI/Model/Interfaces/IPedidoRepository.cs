namespace OhMyDogAPI.Model.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetAllPedidos();
        Task<Pedido> GetPedido(int id);
        Task<Pedido> CreatePedido(Pedido Pedido);
        Task<bool> CancelarPedido(int idPedido);
    }
}
