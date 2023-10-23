using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository() 
        {
            _context = new DatabaseContext();
        }
        public Usuario Login(Credenciais credenciais)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == credenciais.Email);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário inválido");

            return credenciais.Senha == usuario.Senha ? usuario : throw new Exception("Senha inválida");
        }
        public Usuario Create(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
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
            return NullOrEmptyVariable<Usuario>.ThrowIfNull(
                GetByCpf(usuario.Cpf), "Houve um erro ao adicionar o usuário");
        }
        public List<Usuario> GetAll()
        {
            var result = _context.Usuarios
                .AsNoTracking()
                .ToList();

            return result;
        }
        public Usuario? GetById(int id)
        {
            var result = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public Usuario? GetByCpf(string cpf)
        {
            var result = _context.Usuarios.FirstOrDefault(u => u.Cpf == cpf);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(result, "Usuário não encontrado");

            return result;
        }
        public Usuario Update(Usuario usuario)
        {      
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.Telefone = usuario.Telefone;
            oldUser.Email = usuario.Email;
            oldUser.Senha = usuario.Senha;
            oldUser.IsActive = usuario.IsActive;
            oldUser.NomeCompleto = usuario.NomeCompleto;

            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(usuario.Id);
        }
        public Usuario Disable(int id)
        {
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = false;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }

        public Usuario Enable(int id)
        {
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(oldUser, "Usuário não encontrado");

            oldUser.IsActive = true;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
