using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class FavoritesRepository : IFavoriteRepository
    {
        private readonly DatabaseContext _context;

        public FavoritesRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<FavoriteItem?> AddItem(FavoriteItem item)
        {
            try
            {

                if (_context.FavoriteItems.Contains(item))
                    throw new Exception("Este item já está nos favoritos");

                _context.FavoriteItems.Add(item);
                _context.SaveChanges();

                return _context.FavoriteItems
                    .Where(i => i.UsuarioId == item.UsuarioId)
                    .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteItem(FavoriteItem item)
        {
            try
            {
                if (!_context.FavoriteItems.Contains(item))
                    throw new Exception("Este item não está nos favoritos");

                _context.FavoriteItems.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Favorites?> Get(int userId)
        {
            var produtos = _context.FavoriteItems
                .AsNoTracking()
                .Where(i => i.UsuarioId == userId)
                .Select(i => i.ProdutoId)
                .ToList();

            return new Favorites()
            {
                UsuarioId = userId,
                ProdutosId = produtos
            };
        }
    }
}
