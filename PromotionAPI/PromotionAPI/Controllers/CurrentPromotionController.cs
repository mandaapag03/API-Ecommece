using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PromotionAPI.Model;
using PromotionAPI.Repository;

namespace PromotionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentPromotionController : ControllerBase
    {
        private readonly CurrentPromotionRepository _currentPromotionRepository;
        public CurrentPromotionController()
        {
            _currentPromotionRepository = new CurrentPromotionRepository();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CurrentPromotion>>> List()
        {
            try
            {
                var result = await _currentPromotionRepository.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("find/{promotionId}/{productId}")]
        public async Task<ActionResult<CurrentPromotion>> Get(int promotionId, int productId)
        {
            try
            {
                var result = await _currentPromotionRepository.Get(promotionId, productId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("find/{promotionId}")]
        public async Task<ActionResult<List<CurrentPromotion>>> GetByPromotion(int promotionId)
        {
            try
            {
                var result = await _currentPromotionRepository.GetByPromotion(promotionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<CurrentPromotion>> Add([FromBody] CurrentPromotion cp)
        {
            try
            {
                var result = await _currentPromotionRepository.AddProductInPromotion(cp.PromocaoId, cp.ProdutoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{promotionId}/{productId}")]
        public async Task<ActionResult<CurrentPromotion>> Remove(int promotionId, int productId)
        {
            try
            {
                var result = await _currentPromotionRepository.RemoveProductFromPromotion(promotionId, productId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
