using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Enuns;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {

        private readonly DatabaseContext _context;
        private readonly PedidoRepository _pedidoRepository;

        public PagamentoRepository()
        {
            _context = new DatabaseContext();
            _pedidoRepository = new PedidoRepository();
        }

        public async Task<Pagamento> CancelarPagamento(int idPagamento)
        {
            try
            {
                var pagamento = await GetPagamento(idPagamento);

                pagamento.StatusPagamentoId = (int) EStatusPagamento.Cancelado;

                _context.Pagamentos.Update(pagamento);
                _context.SaveChanges();

                return await GetPagamento(idPagamento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pagamento> CreatePagamento(Pagamento pagamento, int pedidoId)
        {
            try
            {
                var pedido = await _pedidoRepository.GetPedido(pedidoId);

                pagamento.PedidoId = pedido.Id;
                pagamento.StatusPagamentoId = (int)EStatusPagamento.Pendente;

                await _context.Pagamentos.AddAsync(pagamento);
                _context.SaveChanges();

                var pagamentoId = await _context.Pagamentos.MaxAsync(x => x.Id);
                return await GetPagamento(pagamentoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Pagamento>> GetAllPagamentos()
        {
            return await _context.Pagamentos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pagamento> GetPagamento(int id)
        {
            return NullOrEmptyVariable<Pagamento>.ThrowIfNull(
                await _context.Pagamentos
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .FirstOrDefaultAsync(x => x.Id == id)
                );
        }
        
        public async Task<Pagamento> GetPagamentoByPedido(int idPedido)
        {
            return NullOrEmptyVariable<Pagamento>.ThrowIfNull(
                await _context.Pagamentos
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .FirstOrDefaultAsync(x => x.PedidoId == idPedido)
                );
        }
        public async Task<List<Pagamento>> GetPagamentosFromPedido(int pedidoId)
        {
            return await _context.Pagamentos
                .Where(x => x.PedidoId == pedidoId)
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .ToListAsync();
        }
        public async Task<List<Pagamento>> GetPagamentosFromUsuario(int usuarioId)
        {
            return await _context.Pagamentos
                .Where(x => x.UsuarioId == usuarioId)
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .ToListAsync();
        }

    }
}
