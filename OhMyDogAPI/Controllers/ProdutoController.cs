using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.Interfaces;
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

        [HttpPost("cadastrar")]
        public IActionResult CadastrarProduto(Produto produto)
        {
            try
            {
                return Ok(_produtoRepository.Create(produto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPut("alterar/{id}")]
        public IActionResult AlterarProduto(Produto produto, int id)
        {
            try
            {
                produto.Id = id;
                return Ok(_produtoRepository.Update(produto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterar")]
        public IActionResult AlterarProduto(Produto produto)
        {
            try
            {
                return Ok(_produtoRepository.Update(produto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inativar/{id}")]
        public IActionResult Inativar(int id)
        {
            try
            {
                return Ok(_produtoRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reativar/{id}")]
        public IActionResult Reativar(int id)
        {
            return Ok(_produtoRepository.Enable(id));
        }

    }
}
