using OhMyDogAPI.Model.dto;

namespace OhMyDogAPI.Model.Interfaces
{
    public interface IUsuariosRepository
    {
        List<Usuario> GetAll();
        Usuario? GetById(int id);
        Usuario Create(Usuario usuario);
        Usuario Login(Credenciais credenciais);
        Usuario Update(Usuario usuario);
        Usuario Disable(int id);
    }
}
