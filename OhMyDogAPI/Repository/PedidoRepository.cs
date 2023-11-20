using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Data;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Enuns;
using OhMyDogAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OhMyDogAPI.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DatabaseContext _context;
        private readonly UsuarioRepository _usuarioRepository;
        public PedidoRepository() 
        {
            _context = new DatabaseContext();
            _usuarioRepository = new UsuarioRepository();
        }
        public async Task<Pedido> CreatePedido(Pedido Pedido)
        {
            try
            {
                _usuarioRepository.GetById(Pedido.UsuarioId);

                Pedido.DataPedido = DateOnly.FromDateTime(DateTime.Now);
                Pedido.StatusPedidoId = (int)EStatusPedido.Pendente;

                await _context.Pedidos.AddAsync(Pedido);
                _context.SaveChanges();

                var lastPedidoId = _context.Pedidos.Max(x => x.Id);
                return await GetPedido(lastPedidoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CancelarPedido(int idPedido)
        {
            var pedido = await GetPedido(idPedido);
            pedido.StatusPedidoId = (int) EStatusPedido.Cancelado;

            try
            {
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _context.Pedidos
                .Include(x => x.StatusPedido)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pedido> GetPedido(int id)
        {
            return NullOrEmptyVariable<Pedido>.ThrowIfNull(
                await _context.Pedidos
                .Include(x => x.Usuario)
                .Include(x => x.Endereco)
                .Include(x => x.StatusPedido)
                .Include(x => x.FormaEnvio)
                .FirstOrDefaultAsync(x => x.Id == id),
                "Pedido não encontrado"
            );
        }
    }
}
