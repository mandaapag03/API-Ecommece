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
        public IActionResult ListProducts() 
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(_productRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(Product product)
        {
            try
            {
                return Ok(_productRepository.Create(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPut("change/{id}")]
        public IActionResult ChangeProduct(Product product, int id)
        {
            try
            {
                product.Id = id;
                return Ok(_productRepository.Update(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change")]
        public IActionResult ChangeProduct(Product product)
        {
            try
            {
                return Ok(_productRepository.Update(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inactivate/{id}")]
        public IActionResult Inactivate(int id)
        {
            try
            {
                return Ok(_productRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reactivate/{id}")]
        public IActionResult Reactivate(int id)
        {
            try
            {
                return Ok(_productRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
