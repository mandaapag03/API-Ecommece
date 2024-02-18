using Microsoft.EntityFrameworkCore;
using PromotionAPI.Data;
using PromotionAPI.Model;
using PromotionAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace PromotionAPI.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DatabaseContext _context;
        public PromotionRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<Promotion> Create(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
            _context.SaveChanges();

            var lastPromotion = await _context.Promotions
                .FirstOrDefaultAsync(c => c.Id == _context.Promotions.Max(p => p.Id));

            return NullOrEmptyVariable<Promotion>.ThrowIfNull(lastPromotion, "Erro ao adicionar nova promoção");
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var promotion = await Get(id);
                _context.Promotions.Remove(promotion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Promotion>> GetAll()
        {
            return await _context.Promotions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Promotion> Get(int id)
        {
            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(p => p.Id == id);

            return NullOrEmptyVariable<Promotion>.ThrowIfNull(promotion, "Promoção não encontrada");
        }
    }
}
