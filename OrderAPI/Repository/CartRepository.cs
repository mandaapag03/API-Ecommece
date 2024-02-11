using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DatabaseContext _context;
        public CartRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<CartItem?> AddItem(CartItem item)
        {
            try
            {
                if (_context.CartItems.Contains(item))
                    throw new Exception("Este item já está no carrinho");

                _context.CartItems.Add(item);
                _context.SaveChanges();

                return _context.CartItems
                    .Where(i => i.UsuarioId == item.UsuarioId)
                    .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteItem(CartItem item)
        {
            try
            {
                if (!_context.CartItems.Contains(item))
                    throw new Exception("Este item não está no carrinho");

                _context.CartItems.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cart?> Get(int userId)
        {

            var produtos = _context.CartItems
                .AsNoTracking()
                .Where(i => i.UsuarioId == userId)
                .Select(i => i.ProdutoId)
                .ToList();

            return new Cart()
            {
                UsuarioId = userId,
                ProdutosId = produtos
            };
        }
    }
}
