namespace PromotionAPI.Model.Interfaces
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetAll();
        Task<Promotion> Get(int id);
        Task<Promotion> Create(Promotion promotion);
        Task<bool> Delete(int id);
    }
}
