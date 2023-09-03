using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Model.Interfaces;
using OhMyDogAPI.Repository.Context;
using System.ComponentModel;

namespace OhMyDogAPI.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        DatabaseContext _context;
        EnderecoRepository _enderecoRepository;

        public UsuariosRepository() 
        {
            _context = new DatabaseContext();
            _enderecoRepository = new EnderecoRepository();
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
            return usuario;
        }

        public Usuario Disable(int id)
        {
            throw new NotImplementedException();
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

        public Usuario Login(Credenciais credenciais)
        {
            throw new NotImplementedException();
        }

        public Usuario Update(Usuario usuario)
        {
            throw new NotImplementedException();
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
                nome_completo = usuario.NomeCompleto
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
                TipoUsuario = (ETipoUsuario) dto.id_tipo_usuario
            };
            return usuario;
        }

    }
}
