using Microsoft.AspNetCore.Mvc;
using UserAPI.Model;
using UserAPI.Repository;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        AddressRepository _addressRepository;

        public AddressController()
        {
            _addressRepository = new AddressRepository();
        }

        [HttpGet("list/{userId}")]
        public IActionResult List(int userId)
        {
            try
            {
                return Ok(_addressRepository.GetAll(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            try
            {
                return Ok(_addressRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/{userId}")]
        public IActionResult Insert([FromBody] Address address, [FromRoute] int userId)
        {
            try
            {
                address.UsuarioId = userId;

                return Ok(_addressRepository.Create(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_addressRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
