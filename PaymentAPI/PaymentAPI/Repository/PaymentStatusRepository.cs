using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Model;
using PaymentAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace PaymentAPI.Repository
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private readonly DatabaseContext _context;
        public PaymentStatusRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<PaymentStatus>> GetAll()
        {
            return await _context.PaymentStatus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PaymentStatus> Get(int id)
        {
            return NullOrEmptyVariable<PaymentStatus>.ThrowIfNull(
                await _context.PaymentStatus
                .FirstOrDefaultAsync(x => x.Id == id)
                , "Status de pagamento não encontrado");
        }
    }
}
