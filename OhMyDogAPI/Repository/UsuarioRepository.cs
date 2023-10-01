using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Model.Interfaces;

namespace OhMyDogAPI.Repository
{
    public class UsuarioRepository : IUsuariosRepository
    {
        DatabaseContext _context;
        EnderecoRepository _enderecoRepository;

        public UsuarioRepository() 
        {
            _context = new DatabaseContext();
            _enderecoRepository = new EnderecoRepository();
        }
        public Usuario Login(Credenciais credenciais)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == credenciais.Email);
            if (usuario == null) {throw new Exception("Usuário inválido");}

            return credenciais.Senha == usuario.Senha ? usuario : throw new Exception("Senha inválida");
        }
        public UsuarioComEndereco Create(UsuarioComEndereco usuarioComEndereco)
        {
            var usuario = usuarioComEndereco.Usuario;
            var endereco = usuarioComEndereco.Endereco;

            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                endereco.UsuarioId = _context.Usuarios.Max(u => u.Id);

                _enderecoRepository.Create(endereco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new UsuarioComEndereco()
            {
                Usuario = GetByCpf(usuario.Cpf),
                Endereco = _enderecoRepository.GetEndereco(_context.Enderecos.Max(e=> e.Id))
            };
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
            if (result == null) 
                throw new Exception("Usuário não encontrado");
            
            return result;
        }
        public Usuario? GetByCpf(string cpf)
        {
            var result = _context.Usuarios.FirstOrDefault(u => u.Cpf == cpf);
            if (result == null)
                throw new Exception("Usuário não encontrado");

            return result;
        }
        public Usuario Update(Usuario usuario)
        {      
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

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
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

            oldUser.IsActive = false;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }

        public Usuario Enable(int id)
        {
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

            oldUser.IsActive = true;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }
    }
}
