namespace OhMyDogAPI.Model.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco? GetEndereco(int id);
        Endereco? Create(Endereco endereco);
        Endereco? UpdateEndereco(Endereco endereco);
    }
}
