using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class FormaEnvioRepository : IFormaEnvioRepository
    {
        private DatabaseContext _context;
        public FormaEnvioRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<List<FormaEnvio>> GetAllFormasEnvio()
        {
            return await _context.FormasEnvio.AsNoTracking().ToListAsync();
        }

        public async Task<FormaEnvio> GetFormaEnvio(int id)
        {
            var formaEnvio = await _context.FormasEnvio.FirstOrDefaultAsync(x => x.Id == id);
            return NullOrEmptyVariable<FormaEnvio>.ThrowIfNull(formaEnvio, "Forma de envio não encontrada");
        }
    }
}
