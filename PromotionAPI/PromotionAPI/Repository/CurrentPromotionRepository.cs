using Microsoft.EntityFrameworkCore;
using PromotionAPI.Data;
using PromotionAPI.Model;
using PromotionAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace PromotionAPI.Repository
{
    public class CurrentPromotionRepository : ICurrentPromotionRepository
    {
        private readonly DatabaseContext _context;

        public CurrentPromotionRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<CurrentPromotion> AddProductInPromotion(int promotionId, int productId)
        { 
            try
            {
                var cp = new CurrentPromotion()
                {
                    ProdutoId = productId,
                    PromocaoId = promotionId
                };
                await _context.CurrentPromotions.AddAsync(cp);
                _context.SaveChanges();

                return await Get(promotionId, productId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CurrentPromotion> Get(int promotionId, int productId)
        {
            try
            {
                CurrentPromotion cp = await _context.CurrentPromotions.Where(x => x.PromocaoId == promotionId).FirstOrDefaultAsync(x => x.ProdutoId == productId);
                return NullOrEmptyVariable<CurrentPromotion>.ThrowIfNull(cp, "current promotion does not exists");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CurrentPromotion>> GetAll()
        {
            return await _context.CurrentPromotions.AsNoTracking().ToListAsync(); 
        }

        public async Task<List<CurrentPromotion>> GetByPromotion(int promotionId)
        {
            return await _context.CurrentPromotions.Where(x => x.PromocaoId == promotionId).ToListAsync();
        }

        public async Task<CurrentPromotion> RemoveProductFromPromotion(int promotionId, int productId)
        {
            try
            {
                var cp = await Get(promotionId, productId);
                _context.CurrentPromotions.Remove(cp);
                _context.SaveChanges();

                return cp;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
