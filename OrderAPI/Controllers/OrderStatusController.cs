using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model.Interfaces;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly OrderStatusRepository _orderStatusRepository;

        public OrderStatusController() 
        {
            _orderStatusRepository = new OrderStatusRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListOrderStatus()
        {
            try
            {
                return Ok(await _orderStatusRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderStatus(int id)
        {
            try
            {
                return Ok(await _orderStatusRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
