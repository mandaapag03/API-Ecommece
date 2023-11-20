namespace OhMyDogAPI.Model.Interfaces
{
    public interface IStatusPedidoRepository
    {
        Task<List<StatusPedido>> GetAll();
        Task<StatusPedido> GetStatusPedido(int id);
    }
}
