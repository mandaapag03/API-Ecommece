using InventoryAPI.Model;
using InventoryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryController(IHttpClientFactory httpClientFactory)
        {
            _inventoryRepository = new InventoryRepository(httpClientFactory);
        }

        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetAll()
        {
            try
            {
                return await _inventoryRepository.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Inventory>> Get(int productId)
        {
            try
            {
                return await _inventoryRepository.Get(productId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Inventory>> Add(Inventory inventory)
        {
            try
            {
                return await _inventoryRepository.Add(inventory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<Inventory>> UpdateQuantity(Inventory inventory)
        {
            try
            {
                return await _inventoryRepository.UpdateQuantity(inventory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Inventory>> Delete(int productId)
        {
            try
            {
                return await _inventoryRepository.Delete(productId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
