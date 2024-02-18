using Microsoft.AspNetCore.Mvc;
using PromotionAPI.Model;
using PromotionAPI.Repository;

namespace PromotionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionRepository _promotionRepository;

        public PromotionController()
        {
            _promotionRepository = new PromotionRepository();
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _promotionRepository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                var result = await _promotionRepository.Get(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Promotion promotion)
        {
            try
            {
                var result = await _promotionRepository.Create(promotion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _promotionRepository.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
