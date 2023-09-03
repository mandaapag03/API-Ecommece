using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuariosRepository _usuariosRepository;
        public UsuarioController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IActionResult ListarUsuarios() 
        {
            try
            {
                return Ok(_usuariosRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            try
            {
                return Ok(_usuariosRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastro")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            return Ok(_usuariosRepository.Create(usuario));
        }
    }
}
