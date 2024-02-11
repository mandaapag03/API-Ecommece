namespace UserAPI.Model.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> GetAll(int UserId);
        Address? Get(int id);
        Address? Create(Address Address);
        Address? Update(Address Address);
        bool? Delete(int id);
    }
}
