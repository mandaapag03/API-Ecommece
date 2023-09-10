using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        ProdutoRepository _produtoRepository;
        public ProdutoController() 
        { 
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult ListarProdutos() 
        {
            return Ok(_produtoRepository.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProdutoPorId(int id)
        {
            return Ok(_produtoRepository.GetById(id));
        }

    }
}
