namespace UserAPI.Model.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAll(int UserId);
        Task<Address?> Get(int id);
        Task<Address?> Create(Address Address);
        Task<Address?> Update(Address Address);
        Task<bool?> Delete(int id);
    }
}
