using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class StatusPagamentoRepository : IStatusPagamentoRepository
    {
        private readonly DatabaseContext _context;
        public StatusPagamentoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<StatusPagamento>> GetAll()
        {
            return await _context.StatusPagamentos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StatusPagamento> GetStatusPagamento(int id)
        {
            return NullOrEmptyVariable<StatusPagamento>.ThrowIfNull(
                await _context.StatusPagamentos
                .FirstOrDefaultAsync(x => x.Id == id)
                , "Status de pagamento não encontrado");
        }
    }
}
