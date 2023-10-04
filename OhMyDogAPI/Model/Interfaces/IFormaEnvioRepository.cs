namespace OhMyDogAPI.Model.Interfaces
{
    public interface IFormaEnvioRepository
    {
        Task<List<FormaEnvio>> GetAllFormasEnvio();
        Task<FormaEnvio> GetFormaEnvio(int id);
    }
}
