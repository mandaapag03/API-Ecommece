using Microsoft.AspNetCore.Mvc;
using OrderAPI.Communication;
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

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _orderRepository = new OrderRepository(httpClientFactory);
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

                var canceledOrder = await _orderRepository.Cancel(id);

                return Ok(canceledOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
