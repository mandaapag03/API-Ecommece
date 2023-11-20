using OhMyDogAPI.Data;

namespace OhMyDogAPI.Repository
{
    public class PromocoesAtuaisRepository
    {
        private readonly DatabaseContext _context;

        public PromocoesAtuaisRepository()
        {
            _context = new DatabaseContext();
        }


    }
}
