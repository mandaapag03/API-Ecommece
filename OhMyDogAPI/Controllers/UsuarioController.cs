using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarUsuarios() 
        {
            try
            {
                return Ok(_usuarioRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("buscar/{cpf}")]
        public IActionResult BuscarUsuario(string cpf)
        {
            try
            {
                return Ok(_usuarioRepository.GetByCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cadastro")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                return Ok(_usuarioRepository.Create(usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterar")]
        public IActionResult Atualizar (Usuario usuario)
        {
            try
            {
                return Ok(_usuarioRepository.Update(usuario));
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
                return Ok(_usuarioRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reativar/{id}")]
        public IActionResult Reativar(int id)
        {
            try
            {
                return Ok(_usuarioRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public dynamic Login(Credenciais credenciais)
        {
            try
            {
                var usuario = _usuarioRepository.Login(credenciais);

                if(usuario == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenRepository.GenerateToken(usuario);

                usuario.Senha = "";

                return new
                {
                    usuario = usuario,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
