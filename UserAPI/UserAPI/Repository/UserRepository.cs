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
        public async Task<User> Login(Credentials credentials)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == credentials.Email);
            NullOrEmptyVariable<User>.ThrowIfNull(user, "Usuário inválido");

            return credentials.Senha == user.Senha ? user : throw new Exception("Senha inválida");
        }
        public async Task<User> Create(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Este usuário já está cadastrado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NullOrEmptyVariable<User>.ThrowIfNull(
                await GetByCpf(user.Cpf), "Houve um erro ao adicionar o usuário");
        }
        public async Task<List<User>> GetAll()
        {
            var result = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            return result;
        }
        public async Task<User>? GetById(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public async Task<User>? GetByCpf(string cpf)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Cpf == cpf);
            NullOrEmptyVariable<User>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public async Task<User> Update(User user)
        {
            var oldUser = await _context.Users.FirstOrDefaultAsync(u => u.Cpf == user.Cpf);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.Telefone = user.Telefone;
            oldUser.Email = user.Email;
            oldUser.Senha = user.Senha;
            oldUser.IsActive = user.IsActive;
            oldUser.NomeCompleto = user.NomeCompleto;

            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return await GetByCpf(user.Cpf);
        }
        public async Task<User> Disable(int id)
        {
            var oldUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = false;
            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return await GetById(id);
        }

        public async Task<User> Enable(int id)
        {
            var oldUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            NullOrEmptyVariable<User>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = true;
            _context.Users.Update(oldUser);
            _context.SaveChanges();

            return await GetById(id);
        }
    }
}
