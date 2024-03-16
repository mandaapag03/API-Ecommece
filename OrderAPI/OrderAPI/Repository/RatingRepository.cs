using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DatabaseContext _context;
        public RatingRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<Rating> Add(Rating rating)
        {
            try
            {
                var hasRating =  await _context.Ratings.Where(x => x.ProdutoId == rating.ProdutoId).FirstOrDefaultAsync(x => x.UsuarioId == rating.UsuarioId) != null;
                
                if( hasRating )
                {
                    throw new Exception("Já existe uma avaliação desse usuário nesse produto");
                }

                await _context.Ratings.AddAsync(rating);
                _context.SaveChanges();

                int id = _context.Ratings.Max(x => x.Id);
                return await Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Rating> Delete(int Id)
        {
            try
            {
                var rating = await Get(Id);
                _context.Ratings.Remove(rating);
                _context.SaveChanges();
                return rating;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Rating> Get(int id)
        {
            try
            {
                return NullOrEmptyVariable<Rating>.ThrowIfNull(await _context.Ratings.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Rating>> GetAllByProduct(int productId)
        {
            try
            {
                return await _context.Ratings.AsNoTracking().Where(x => x.ProdutoId == productId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<List<Rating>> GetAllByUser(int userId)
        {
            try
            {
                return await _context.Ratings.AsNoTracking().Where(x => x.UsuarioId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
