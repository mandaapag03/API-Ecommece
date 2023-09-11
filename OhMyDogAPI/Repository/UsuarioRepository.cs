using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Model.Interfaces;
using System.ComponentModel;

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
            var usuario = _context.Usuarios.FirstOrDefault(u => u.email == credenciais.Email);
            if (usuario == null) {throw new Exception("Usuário inválido");}

            return credenciais.Senha == usuario.senha ? ConvertDtoToUsuario(usuario) : throw new Exception("Senha inválida");
        }
        public Usuario Create(Usuario usuario)
        {
            var endereco = _enderecoRepository.Create(usuario.EnderecoInfo);

            usuario.EnderecoInfo = endereco;

            var result = _context.Usuarios.Add(ConvertUsuarioToDto(usuario));
            _context.SaveChanges();

            if (result == null)
            {
                throw new Exception("Não foi possível cadastrar o usuário");
            }
            return GetByCpf(usuario.Cpf);
        }
        public List<Usuario> GetAll()
        {
            var result = new List<Usuario>();

            List<UsuarioDto> listaUsuarios = _context.Usuarios.ToList();

            foreach (var u in listaUsuarios)
            {
               result.Add(ConvertDtoToUsuario(u));
            }

            return result;
        }
        public Usuario? GetById(int id)
        {
            var result = _context.Usuarios.FirstOrDefault(u => u.id == id);
            if (result == null) 
                throw new Exception("Usuário não encontrado");
            
            return ConvertDtoToUsuario(result);
        }
        public Usuario? GetByCpf(string cpf)
        {
            var result = _context.Usuarios.FirstOrDefault(u => u.cpf == cpf);
            if (result == null)
                throw new Exception("Usuário não encontrado");

            return ConvertDtoToUsuario(result);
        }
        public Usuario Update(Usuario usuario)
        {
            var userParamDto = ConvertUsuarioToDto(usuario);
            if(userParamDto == null) { throw new ArgumentNullException("Usuário não encontrado"); }
            
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.cpf == userParamDto.cpf);
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

            oldUser.telefone = userParamDto.telefone;
            oldUser.email = userParamDto.email;
            oldUser.senha = userParamDto.senha;
            oldUser.is_active = userParamDto.is_active;
            oldUser.nome_completo = userParamDto.nome_completo;
            oldUser.id_tipo_usuario = userParamDto.id_tipo_usuario;

            var oldEndereco = _context.Enderecos.FirstOrDefault(e => e.Id == userParamDto.id_endereco);
            if (oldEndereco == null) { throw new ArgumentNullException("Endereço não encontrado"); }
            var endereco = usuario.EnderecoInfo;

            oldEndereco.Cep = endereco.Cep;
            oldEndereco.Logradouro = endereco.Logradouro;
            oldEndereco.Numero = endereco.Numero;
            oldEndereco.Bairro = endereco.Bairro;
            oldEndereco.Uf = endereco.Uf;
            oldEndereco.Cidade = endereco.Cidade;
            oldEndereco.Complemento = endereco.Complemento;

            _context.Enderecos.Update(oldEndereco);
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(usuario.Id);
        }
        public Usuario Disable(int id)
        {
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.id == id);
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

            oldUser.is_active = false;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }

        public Usuario Enable(int id)
        {
            var oldUser = _context.Usuarios.FirstOrDefault(u => u.id == id);
            if (oldUser == null) { throw new ArgumentNullException("Usuário não encontrado"); }

            oldUser.is_active = true;
            _context.Usuarios.Update(oldUser);
            _context.SaveChanges();

            return GetById(id);
        }
        private UsuarioDto ConvertUsuarioToDto(Usuario usuario)
        {
            var dto = new UsuarioDto()
            {
                email = usuario.Email,
                id = usuario.Id,
                id_endereco = usuario.EnderecoInfo.Id,
                id_tipo_usuario = (int)usuario.TipoUsuario,
                senha = usuario.Senha,
                telefone = usuario.Telefone,
                cpf = usuario.Cpf,
                nome_completo = usuario.NomeCompleto,
                is_active = usuario.IsActive    
            };
            return dto;
        }
        private Usuario ConvertDtoToUsuario(UsuarioDto dto)
        {
            var usuario = new Usuario()
            {
                Id = dto.id,
                Cpf = dto.cpf,
                Email = dto.email,
                EnderecoInfo = _enderecoRepository.GetEndereco(dto.id_endereco),
                NomeCompleto = dto.nome_completo,
                Senha = dto.senha,
                Telefone = dto.telefone,
                TipoUsuario = (ETipoUsuario)dto.id_tipo_usuario,
                IsActive = dto.is_active
            };
            return usuario;
        }

    }
}
