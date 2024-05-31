using Microsoft.EntityFrameworkCore;
using OrderAPI.Communication;
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
        private readonly PaymentCommunication _paymentCommunication;
        private readonly EmailCommunication _emailCommunication;
        private readonly UserCommunication _userCommunication;


        public OrderRepository(IHttpClientFactory httpClientFactory)
        {
            _context = new DatabaseContext();
            _orderItemRepository = new OrderItemRepository();
            _paymentCommunication = new PaymentCommunication(httpClientFactory);
            _emailCommunication = new EmailCommunication(httpClientFactory);
            _userCommunication = new UserCommunication(httpClientFactory);
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            try
            {
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

                var order = await Get(lastOrderId);

                var payment = await _paymentCommunication.CreatePayment(newOrder.UsuarioId, newOrder.FormaPagamentoId, newOrder.Qtd_parecelas, newOrder.Total, order.Id);

                try
                {
                    var user = await _userCommunication.GetUserData(newOrder.UsuarioId);
                    NullOrEmptyVariable<User>.ThrowIfNull(user, "Não foi possível buscar os dados desse usuário");
                    await _emailCommunication.OrderCreatedEmail(user.Email);
                }
                catch { }

                return new
                {
                    order = await Get(lastOrderId),
                    orderItems = await _orderItemRepository.GetAll(order.Id),
                    payment = payment
                };
            }
            catch (Exception ex)
            {
                var lastOrderId = _context.Orders.Max(x => x.Id);
                await Cancel(lastOrderId);

                throw new Exception(ex.Message);
            }
        }

        public async Task<dynamic> Cancel(int orderId)
        {
            var order = await Get(orderId);
            order.StatusPedidoId = (int)EOrderStatus.Cancelado;

            try
            {
                _context.Orders.Update(order);
                _context.SaveChanges();

                var payment = await _paymentCommunication.CancelPayment(orderId);

                return new
                {
                    order = await Get(orderId),
                    payment = payment
                };
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
                .Include(x => x.FormaEnvio)
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
