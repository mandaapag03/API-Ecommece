using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        EnderecoRepository _enderecoRepository;

        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        [HttpGet("listar/{idUsuario}")]
        public IActionResult ListarEnderecos(int idUsuario)
        {
            try
            {
                return Ok(_enderecoRepository.GetAllEnderecosOfUser(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEndereco(int id)
        {
            try
            {
                return Ok(_enderecoRepository.GetEndereco(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastrar/{idUsuario}")]
        public IActionResult InserirEndereco([FromBody] Endereco endereco, [FromRoute] int idUsuario)
        {
            try
            {
                endereco.UsuarioId = idUsuario;

                return Ok(_enderecoRepository.Create(endereco));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirEndereco(int id)
        {
            try
            {
                return Ok(_enderecoRepository.DeleteEndereco(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
