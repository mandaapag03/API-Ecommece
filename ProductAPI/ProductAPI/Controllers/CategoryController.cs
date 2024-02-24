using Microsoft.AspNetCore.Mvc;
using ProductAPI.Model;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository;

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            try
            {
                return Ok(await _categoryRepository.GetAll());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscarcategory(int id)
        {
            try
            {
                return Ok(await _categoryRepository.GetById(id));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("subCategories/list/{id}")]
        public async Task<IActionResult> ListSubCategories(int id)
        {
            try
            {
                return Ok(await _categoryRepository.GetSubCategoriesById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Insert(Category category)
        {
            try
            {
                return Ok(await _categoryRepository.Create(category));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                return Ok(await _categoryRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
