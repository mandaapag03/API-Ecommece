using PromotionAPI.Data;

namespace PromotionAPI.Repository
{
    public class CurrentlyPromotionRepository
    {
        private readonly DatabaseContext _context;

        public CurrentlyPromotionRepository()
        {
            _context = new DatabaseContext();
        }


    }
}
