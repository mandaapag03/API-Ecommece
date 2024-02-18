using Microsoft.AspNetCore.Mvc;
using OrderAPI.Model;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesRepository _favoritesRepository;
        public FavoritesController()
        {
            _favoritesRepository = new FavoritesRepository();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> Get([FromRoute] int userId)
        {
            try
            {
                var result = await _favoritesRepository.Get(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("item/add")]
        public async Task<ActionResult> AddItem([FromBody] FavoriteItem item)
        {
            try
            {
                var result = await _favoritesRepository.AddItem(item);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("item/delete")]
        public async Task<IActionResult> DeleteItem([FromBody] FavoriteItem item)
        {
            try
            {
                var result = await _favoritesRepository.DeleteItem(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

