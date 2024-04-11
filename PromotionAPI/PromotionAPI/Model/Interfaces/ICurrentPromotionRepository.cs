namespace PromotionAPI.Model.Interfaces
{
    public interface ICurrentPromotionRepository
    {
        Task<CurrentPromotion> Get(int promotionId, int productId);
        Task<List<CurrentPromotion>> GetByPromotion(int promotionId);
        Task<List<CurrentPromotion>> GetAll();
        Task<CurrentPromotion> AddProductInPromotion(int promotionId, int productId);
        Task<CurrentPromotion> RemoveProductFromPromotion(int promotionId, int productId);
    }
}
