using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly PromocaoRepository _promocaoRepository;

        public PromocaoController()
        {
            _promocaoRepository = new PromocaoRepository();
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarPromocoes()
        {
            try
            {
                var result = await _promocaoRepository.GetAllPromocoes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarPromocao(int id)
        {
            try
            {
                var result = await _promocaoRepository.GetPromocao(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarPromocao([FromBody] Promocao promocao)
        {
            try
            {
                var result = await _promocaoRepository.CreatePromocao(promocao);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirPromocao(int id)
        {
            try
            {
                var result = await _promocaoRepository.DeletePromocao(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
