using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Model;
using UserAPI.Model.dto;
using UserAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository() 
        {
            _context = new DatabaseContext();
        }
        public User Login(Credentials credentials)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == credentials.Email);
            NullOrEmptyVariable<User>.ThrowIfNull(user, "Usuário inválido");

            return credentials.Senha == user.Senha ? user : throw new Exception("Senha inválida");
        }
        public User Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new Exception("Este usuário já está cadastrado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NullOrEmptyVariable<User>.ThrowIfNull(
                GetByCpf(user.Cpf), "Houve um erro ao adicionar o usuário");
        }
        public List<User> GetAll()
        {
            var result = _context.Users
                .AsNoTracking()
                .ToList();

            return result;
        }
        public User? GetById(int id)
        {
            var result = _context.Users.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public User? GetByCpf(string cpf)
        {
            var result = _context.Users.FirstOrDefault(u => u.Cpf == cpf);
            NullOrEmptyVariable<User>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public User Update(User user)
        {      
            var oldUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.Telefone = user.Telefone;
            oldUser.Email = user.Email;
            oldUser.Senha = user.Senha;
            oldUser.IsActive = user.IsActive;
            oldUser.NomeCompleto = user.NomeCompleto;

            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return GetById(user.Id);
        }
        public User Disable(int id)
        {
            var oldUser = _context.Users.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = false;
            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }

        public User Enable(int id)
        {
            var oldUser = _context.Users.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = true;
            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
