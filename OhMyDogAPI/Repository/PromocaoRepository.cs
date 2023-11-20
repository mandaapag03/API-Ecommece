using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly DatabaseContext _context;
        public PromocaoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<Promocao> CreatePromocao(Promocao promocao)
        {
            await _context.Promocoes.AddAsync(promocao);
            _context.SaveChanges();

            var lastPromocao = await _context.Promocoes
                .FirstOrDefaultAsync(c => c.Id == _context.Promocoes.Max(p => p.Id));

            return NullOrEmptyVariable<Promocao>.ThrowIfNull(lastPromocao, "Erro ao adicionar nova promoção");
        }

        public async Task<bool> DeletePromocao(int id)
        {
            try
            {
                var promocao = await GetPromocao(id);
                _context.Promocoes.Remove(promocao);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Promocao>> GetAllPromocoes()
        {
            return await _context.Promocoes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Promocao> GetPromocao(int id)
        {
            var promocao = await _context.Promocoes
                .FirstOrDefaultAsync(p => p.Id == id);

            return NullOrEmptyVariable<Promocao>.ThrowIfNull(promocao, "Promoção não encontrada");
        }
    }
}
