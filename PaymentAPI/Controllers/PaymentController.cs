using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Repository;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentController()
        {
            _paymentRepository = new PaymentRepository();
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            try
            {
                return Ok(await _paymentRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> ListPaymentsByUser(int userId) 
        {
            try
            {
                return Ok(await _paymentRepository.GetByUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> ListPaymentsByOrder(int orderId) 
        {
            try
            {
                return Ok(await _paymentRepository.GetByOrder(orderId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            try
            {
                return Ok(await _paymentRepository.Get(id));
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
                return Ok(await _paymentRepository.Cancel(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
