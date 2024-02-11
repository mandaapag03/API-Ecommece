using Microsoft.AspNetCore.Mvc;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private ShippingRepository _shippingRepository;

        public ShippingController()
        {
            _shippingRepository = new ShippingRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListShipping()
        {
            try
            {
                return Ok(await _shippingRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipping(int id)
        {
            try
            {
                return Ok(await _shippingRepository.Get(id));
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
    }
}
