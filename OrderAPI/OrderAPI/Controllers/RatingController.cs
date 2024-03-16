using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        RatingRepository _ratingRepository;
        public RatingController()
        {
            _ratingRepository = new RatingRepository();
        }

        [HttpGet("list/product/{produtoId}")]
        public async Task<ActionResult<List<Rating>>> ListByProduct(int produtoId) 
        {
            try
            {
                return Ok(await _ratingRepository.GetAllByProduct(produtoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        [HttpGet("list/user/{userId}")]
        public async Task<ActionResult<List<Rating>>> ListByUser(int userId) 
        {
            try
            {
                return Ok(await _ratingRepository.GetAllByUser(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> Get(int id) 
        {
            try
            {
                return Ok(await _ratingRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        [HttpPost("add")]
        public async Task<ActionResult<Rating>> Add([FromBody] Rating rating)
        {
            try
            {
                return Ok(await _ratingRepository.Add(rating));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
                
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Rating>> Delete(int id) 
        {
            try
            {
                return Ok(await _ratingRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
