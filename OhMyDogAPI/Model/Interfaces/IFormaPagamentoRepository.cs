namespace OhMyDogAPI.Model.Interfaces
{
    public interface IFormaPagamentoRepository
    {
        Task<List<FormaPagamento>> GetAllFormasPagamento();
        Task<FormaPagamento> GetFormaPagamento(int id);
    }
}
