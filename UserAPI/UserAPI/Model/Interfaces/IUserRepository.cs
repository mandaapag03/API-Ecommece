using UserAPI.Model.dto;

namespace UserAPI.Model.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User>? GetById(int id);
        Task<User>? GetByCpf(string cpf);
        Task<User> Create(User user);
        Task<User> Login(Credentials credentials);
        Task<User> Update(User user);
        Task<User> Disable(int id);
        Task<User> Enable(int id);
    }
}
