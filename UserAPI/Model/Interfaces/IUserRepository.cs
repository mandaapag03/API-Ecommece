using UserAPI.Model.dto;

namespace UserAPI.Model.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User? GetByCpf(string cpf);
        User Create(User user);
        User Login(Credentials credentials);
        User Update(User user);
        User Disable(int id);
        User Enable(int id);
    }
}
