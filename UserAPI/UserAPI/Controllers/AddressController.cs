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
        public async Task<ActionResult<Address>> List(int userId)
        {
            try
            {
                return Ok(await _addressRepository.GetAll(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Find(int id)
        {
            try
            {
                return Ok(await _addressRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register/{userId}")]
        public async Task<ActionResult<Address>> Insert([FromBody] Address address, [FromRoute] int userId)
        {
            try
            {
                address.UsuarioId = userId;

                return Ok(await _addressRepository.Create(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> Update([FromBody] Address address, [FromRoute] int id)
        {
            try
            {
                address.Id = id;
                return Ok(await _addressRepository.Update(address));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> Delete(int id)
        {
            try
            {
                return Ok(await _addressRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
