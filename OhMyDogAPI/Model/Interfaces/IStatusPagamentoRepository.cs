namespace OhMyDogAPI.Model.Interfaces
{
    public interface IStatusPagamentoRepository
    {
        Task<List<StatusPagamento>> GetAll();
        Task<StatusPagamento> GetStatusPagamento(int id);
    }
}
