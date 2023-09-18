using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaRepository _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        [HttpGet]
        public IActionResult ListarCategorias() 
        {
            try
            {
                return Ok(_categoriaRepository.GetAllCategorias());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarCategoria(int id)
        {
            try
            {
                return Ok(_categoriaRepository.GetById(id));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criar")]
        public IActionResult InserirCategoria(Categoria categoria)
        {
            try
            {
                return Ok(_categoriaRepository.Create(categoria));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirCategoria(int id)
        {
            try
            {
                return Ok(_categoriaRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
