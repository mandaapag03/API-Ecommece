namespace OhMyDogAPI.Model.Interfaces
{
    public interface IEnderecoRepository
    {
        List<Endereco> GetAllEnderecosOfUser(int idUsuario);
        Endereco? GetEndereco(int id);
        Endereco? Create(Endereco endereco);
        Endereco? UpdateEndereco(Endereco endereco);
        bool? DeleteEndereco(int idEndereco);
    }
}
