namespace PaymentAPI.Model.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethod>> GetAll();
        Task<PaymentMethod> Get(int id);
    }
}
