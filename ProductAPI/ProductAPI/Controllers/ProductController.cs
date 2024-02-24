using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ProductAPI.Model;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductRepository _productRepository;
        public ProductController() 
        { 
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts() 
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                return Ok(await _productRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Product product)
        {
            try
            {
                return Ok(await _productRepository.Create(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPut("change/{id}")]
        public async Task<IActionResult> ChangeProduct(Product product, int id)
        {
            try
            {
                product.Id = id;
                return Ok(await _productRepository.Update(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change")]
        public async Task<IActionResult> ChangeProduct(Product product)
        {
            try
            {
                return Ok(await _productRepository.Update(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inactivate/{id}")]
        public async Task<IActionResult> Inactivate(int id)
        {
            try
            {
                return Ok(await _productRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reactivate/{id}")]
        public async Task<IActionResult> Reactivate(int id)
        {
            try
            {
                return Ok(await _productRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
