using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Model;
using OrderAPI.Model.DTO;
using OrderAPI.Model.Enuns;
using OrderAPI.Model.Interfaces;
using VerifyNullablesObjects;

namespace OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;
        private readonly OrderItemRepository _orderItemRepository;

        public OrderRepository() 
        {
            _context = new DatabaseContext();
            _orderItemRepository = new OrderItemRepository();
        }
        public async Task<object> Create(NewOrder newOrder)
        {
            try
            {
                var order = new Order
                {
                    UsuarioId = newOrder.UsuarioId,
                    FormaEnvioId = newOrder.FormaEnvioId,
                    EnderecoId = newOrder.EnderecoId
                };

                order.DataPedido = DateOnly.FromDateTime(DateTime.Now);
                order.StatusPedidoId = (int)EOrderStatus.Pendente;

                await _context.Orders.AddAsync(order);
                _context.SaveChanges();

                var lastOrderId = _context.Orders.Max(x => x.Id);

                foreach (var item in newOrder.ItensPedido)
                {
                    await _orderItemRepository.Insert(new OrderItem
                    {
                        PedidoId = lastOrderId,
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade
                    });
                }
                return new
                {
                    order = await Get(lastOrderId),
                    orderItems = await _orderItemRepository.GetAll(order.Id)
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Cancel(int idPedido)
        {
            var order = await Get(idPedido);
            order.StatusPedidoId = (int) EOrderStatus.Cancelado;

            try
            {
                _context.Orders.Update(order);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Include(x => x.StatusPedido)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return NullOrEmptyVariable<Order>.ThrowIfNull(
                await _context.Orders
                .Include(x => x.StatusPedido)
                .Include(x => x.FormaEnvio)
                .FirstOrDefaultAsync(x => x.Id == id),
                "Pedido não encontrado"
            );
        }
    }
}
