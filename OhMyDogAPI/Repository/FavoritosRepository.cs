using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class FavoritosRepository : IFavoritoRepository
    {
        private readonly DatabaseContext _context;

        public FavoritosRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<ItemFavoritos?> AddItemToFavoritos(ItemFavoritos item)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == item.UsuarioId);
                NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                NullOrEmptyVariable<Produto>.ThrowIfNull(produto, "Produto não encontrado");

                if (_context.ItensFavoritos.Contains(item))
                    throw new Exception("Este item já está nos favoritos");

                _context.ItensFavoritos.Add(item);
                _context.SaveChanges();

                return _context.ItensFavoritos
                    .Where(i => i.UsuarioId == item.UsuarioId)
                    .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteItemFromFavoritos(ItemFavoritos item)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == item.UsuarioId);
                NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                NullOrEmptyVariable<Produto>.ThrowIfNull(produto, "Produto não encontrado");

                if (!_context.ItensFavoritos.Contains(item))
                    throw new Exception("Este item não está nos favoritos");

                _context.ItensFavoritos.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Favoritos?> GetFavoritos(int idUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

            var produtos = _context.ItensFavoritos
                .AsNoTracking()
                .Where(i => i.UsuarioId == idUsuario)
                .Select(i => i.Produto)
                .ToList();

            return new Favoritos()
            {
                UsuarioId = idUsuario,
                Produtos = NullOrEmptyVariable<List<Produto>>.ThrowIfNull(produtos, "Produto inválido")
            };
        }
    }
}
