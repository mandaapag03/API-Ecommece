namespace OhMyDogAPI.Model.Interfaces
{
    public interface IPromocaoRepository
    {
        Task<List<Promocao>> GetAllPromocoes();
        Task<Promocao> GetPromocao(int id);
        Task<Promocao> CreatePromocao(Promocao promocao);
        Task<bool> DeletePromocao(int id);
    }
}
