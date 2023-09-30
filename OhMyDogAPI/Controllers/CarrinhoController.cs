using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly CarrinhoRepository _carrinhoRepository;
        public CarrinhoController()
        {
            _carrinhoRepository = new CarrinhoRepository();
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult> BuscarCarrinho([FromRoute] int idUsuario)
        {
            try
            {
                var result = await _carrinhoRepository.GetCarrinho(idUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("item/adicionar")]
        public async Task<ActionResult> AdicionarItemAoCarrinho([FromBody] ItemCarrinho item)
        {
            try
            {
                var result = await _carrinhoRepository.AddItemToCarrinho(item);
                return Ok(result);

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("item/excluir")]
        public async Task<IActionResult> ExcluirItemDoCarrinho([FromBody] ItemCarrinho item)
        {
            try
            {
                var result = await _carrinhoRepository.DeleteItemFromCarrinho(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
