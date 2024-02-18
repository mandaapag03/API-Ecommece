using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository _cartRepository;
        public CartController()
        {
            _cartRepository = new CartRepository();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> Get([FromRoute] int userId)
        {
            try
            {
                var result = await _cartRepository.Get(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("item/add")]
        public async Task<ActionResult> AddItem([FromBody] CartItem item)
        {
            try
            {
                var result = await _cartRepository.AddItem(item);
                return Ok(result);

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("item/delete")]
        public async Task<IActionResult> DeleteItem([FromBody] CartItem item)
        {
            try
            {
                var result = await _cartRepository.DeleteItem(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
