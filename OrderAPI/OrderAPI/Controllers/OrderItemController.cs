using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model.Interfaces;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemRepository _orderItemRepository;

        public OrderItemController()
        {
            _orderItemRepository = new OrderItemRepository();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult> ListItemsByOrder(int orderId)
        {
            try
            {
                return Ok(await _orderItemRepository.GetAll(orderId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}/{orderItemId}")]
        public async Task<ActionResult> GetItemsByOrder([FromQuery]int orderId, [FromQuery] int orderItemId)
        {
            try
            {
                return Ok(await _orderItemRepository.GetItemByOrderId(orderId, orderItemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
