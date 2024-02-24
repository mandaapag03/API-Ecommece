using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Model;
using PaymentAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace PaymentAPI.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private DatabaseContext _context;
        public PaymentMethodRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<PaymentMethod>> GetAll()
        {
            return await _context.PaymentMethods.AsNoTracking().ToListAsync();
        }

        public async Task<PaymentMethod> Get(int id)
        {
            var paymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == id);
            return NullOrEmptyVariable<PaymentMethod>.ThrowIfNull(paymentMethod, "Forma de Pagamento não encontrada");
        }
    }
}
