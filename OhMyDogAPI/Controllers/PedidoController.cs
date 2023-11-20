using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Model.Enuns;
using OhMyDogAPI.Repository;
using System.Linq.Expressions;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly PagamentoRepository _pagamentoRepository;
        private readonly ItemPedidoRepository _itemPedidoRepository;

        public PedidoController()
        {
            _pedidoRepository = new PedidoRepository();
            _pagamentoRepository = new PagamentoRepository();
            _itemPedidoRepository = new ItemPedidoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            try
            {
                return Ok(await _pedidoRepository.GetAllPedidos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPedido(int id)
        {
            try
            {
                return Ok(await _pedidoRepository.GetPedido(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criar")]
        public async Task<ActionResult> CriarNovoPedido([FromBody] NovoPedido novoPedido)
        {
            try
            {
                var pedido = await _pedidoRepository.CreatePedido(new Pedido 
                { 
                    UsuarioId = novoPedido.UsuarioId,
                    FormaEnvioId = novoPedido.FormaEnvioId,
                    EnderecoId = novoPedido.EnderecoId
                });

                foreach(var item in novoPedido.ItensPedido)
                {
                    await _itemPedidoRepository.Insert(new ItemPedido
                    {
                        PedidoId = pedido.Id,
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade
                    }) ;
                }

                var pagamento = await _pagamentoRepository.CreatePagamento(new Pagamento
                {
                    UsuarioId = novoPedido.UsuarioId,
                    FormaPagamentoId = novoPedido.FormaPagamentoId,
                    QuantidadeParcelas = novoPedido.Qtd_parecelas,
                    Total = novoPedido.Total
                }, 
                pedido.Id);

                return Ok(new
                {
                    pagamento = pagamento,
                    pedido = pedido,
                    itensPedido = await _itemPedidoRepository.GetAll(pedido.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> CancelarPedido(int id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetPedido(id);
                var pagamento = await _pagamentoRepository.GetPagamentoByPedido(pedido.Id);

                var IsCancelado = await _pedidoRepository.CancelarPedido(id);

                if (IsCancelado)
                {
                    if (pagamento.StatusPagamentoId == (int)EStatusPagamento.Pendente)
                        await _pagamentoRepository.CancelarPagamento(pagamento.Id);
                }

                return Ok(IsCancelado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
