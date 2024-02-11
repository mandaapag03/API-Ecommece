using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Model;
using PaymentAPI.Model.Enuns;
using PaymentAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace PaymentAPI.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly DatabaseContext _context;
        public PaymentRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<Payment> Cancel(int paymentId)
        {
            try
            {
                var payment = await Get(paymentId);

                payment.StatusPagamentoId = (int) EPaymentStatus.Cancelado;

                _context.Payments.Update(payment);
                _context.SaveChanges();

                return await Get(paymentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Payment> Create(Payment payment, int orderId)
        {
            try
            {
                payment.PedidoId = orderId;
                payment.StatusPagamentoId = (int)EPaymentStatus.Pendente;

                await _context.Payments.AddAsync(payment);
                _context.SaveChanges();

                var paymentId = await _context.Payments.MaxAsync(x => x.Id);
                return await Get(paymentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Payment> Get(int id)
        {
            return NullOrEmptyVariable<Payment>.ThrowIfNull(
                await _context.Payments
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .FirstOrDefaultAsync(x => x.Id == id)
                );
        }
        
        public async Task<Payment> GetByOrder(int orderId)
        {
            return NullOrEmptyVariable<Payment>.ThrowIfNull(
                await _context.Payments
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .FirstOrDefaultAsync(x => x.PedidoId == orderId)
                );
        }
        //public async Task<List<Payment>> GetPagamentosFromPedido(int pedidoId)
        //{
        //    return await _context.Payments
        //        .Where(x => x.PedidoId == pedidoId)
        //        .Include(x => x.StatusPagamento)
        //        .Include(x => x.FormaPagamento)
        //        .ToListAsync();
        //}
        public async Task<List<Payment>> GetByUser(int userId)
        {
            return await _context.Payments
                .Where(x => x.UsuarioId == userId)
                .Include(x => x.StatusPagamento)
                .Include(x => x.FormaPagamento)
                .ToListAsync();
        }

    }
}
