using OhMyDogAPI.Model.dto;

namespace OhMyDogAPI.Model.Interfaces
{
    public interface IUsuariosRepository
    {
        List<Usuario> GetAll();
        Usuario? GetById(int id);
        Usuario? GetByCpf(string cpf);
        UsuarioComEndereco Create(UsuarioComEndereco usuarioComEndereco);
        Usuario Login(Credenciais credenciais);
        Usuario Update(Usuario usuario);
        Usuario Disable(int id);
        Usuario Enable(int id);
    }
}
