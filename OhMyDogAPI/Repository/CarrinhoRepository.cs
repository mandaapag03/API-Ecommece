using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class CarrinhoRepository : ICarrrinhoRepository
    {
        private readonly DatabaseContext _context;
        public CarrinhoRepository()
        {
            _context = new DatabaseContext();
        }

        public async Task<ItemCarrinho?> AddItemToCarrinho(ItemCarrinho item)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == item.UsuarioId);
                NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                NullOrEmptyVariable<Produto>.ThrowIfNull(produto, "Produto não encontrado");

                if (_context.ItensCarrinho.Contains(item))
                    throw new Exception("Este item já está no carrinho");

                _context.ItensCarrinho.Add(item);
                _context.SaveChanges();

                return _context.ItensCarrinho
                    .Where(i => i.UsuarioId == item.UsuarioId)
                    .FirstOrDefault(i => i.ProdutoId == item.ProdutoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteItemFromCarrinho(ItemCarrinho item)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == item.UsuarioId);
                NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

                var produto = _context.Produtos.FirstOrDefault(p => p.Id == item.ProdutoId);
                NullOrEmptyVariable<Produto>.ThrowIfNull(produto, "Produto não encontrado");

                if (!_context.ItensCarrinho.Contains(item))
                    throw new Exception("Este item não está no carrinho");

                _context.ItensCarrinho.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Carrinho?> GetCarrinho(int idUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
            NullOrEmptyVariable<Usuario>.ThrowIfNull(usuario, "Usuário não encontrado");

            var produtos = _context.ItensCarrinho
                .AsNoTracking()
                .Where(i => i.UsuarioId == idUsuario)
                .Select(i => i.Produto)
                .ToList();

            return new Carrinho()
            {
                UsuarioId = idUsuario,
                Produtos = NullOrEmptyVariable<List<Produto>>.ThrowIfNull(produtos, "Produto inválido")
            };
        }
    }
}
