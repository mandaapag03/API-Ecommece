namespace PaymentAPI.Model.Interfaces
{
    public interface IPaymentStatusRepository
    {
        Task<List<PaymentStatus>> GetAll();
        Task<PaymentStatus> Get(int id);
    }
}
