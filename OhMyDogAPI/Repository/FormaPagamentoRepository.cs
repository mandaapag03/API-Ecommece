using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private DatabaseContext _context;
        public FormaPagamentoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<FormaPagamento>> GetAllFormasPagamento()
        {
            return await _context.FormasPagamento.AsNoTracking().ToListAsync();
        }

        public async Task<FormaPagamento> GetFormaPagamento(int id)
        {
            var formaPagamento = await _context.FormasPagamento.FirstOrDefaultAsync(x => x.Id == id);
            return NullOrEmptyVariable<FormaPagamento>.ThrowIfNull(formaPagamento, "Forma de Pagamento não encontrada");
        }
    }
}
