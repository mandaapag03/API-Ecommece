namespace PaymentAPI.Model.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAll();
        Task<Payment> Get(int id);
        Task<Payment> GetByOrder(int orderId);
        Task<List<Payment>> GetByUser(int userId);
        Task<Payment> Create(Payment payment, int orderId);
        Task<Payment> Cancel(int id);
    }
}
