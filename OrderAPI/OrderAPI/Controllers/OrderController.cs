using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model;
using OrderAPI.Model.DTO;
using OrderAPI.Model.Enuns;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return Ok(await _orderRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                return Ok(await _orderRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] NewOrder newOrder)
        {
            try
            {
                return Ok(await _orderRepository.Create(newOrder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var order = await _orderRepository.Get(id);
                //var pagamento = await _pagamentoRepository.GetPagamentoByorder(order.Id);

                var IsCanceled = await _orderRepository.Cancel(id);

                //if (IsCancelado)
                //{
                //    if (pagamento.StatusPagamentoId == (int)EOrderStatus.Pendente)
                //        await _pagamentoRepository.CancelarPagamento(pagamento.Id);
                //}

                return Ok(IsCanceled);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
