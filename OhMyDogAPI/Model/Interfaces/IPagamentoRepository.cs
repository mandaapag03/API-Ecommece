namespace OhMyDogAPI.Model.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<List<Pagamento>> GetAllPagamentos();
        Task<Pagamento> GetPagamento(int id);
        Task<List<Pagamento>> GetPagamentosFromPedido(int pedidoId);
        Task<List<Pagamento>> GetPagamentosFromUsuario(int usuarioId);
        Task<Pagamento> CreatePagamento(Pagamento pagamento, int pedidoId);
        Task<Pagamento> CancelarPagamento(int idPagamento);
    }
}
