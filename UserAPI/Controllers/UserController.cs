using Microsoft.AspNetCore.Mvc;
using UserAPI.Model;
using UserAPI.Model.dto;
using UserAPI.Repository;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IActionResult ListUsers() 
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("find/{cpf}")]
        public IActionResult FindUser(string cpf)
        {
            try
            {
                return Ok(_userRepository.GetByCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            try
            {
                return Ok(_userRepository.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterar")]
        public IActionResult Update(User user)
        {
            try
            {
                return Ok(_userRepository.Update(user));
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
                return Ok(_userRepository.Disable(id));
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
                return Ok(_userRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public dynamic Login(Credentials credentials)
        {
            try
            {
                var user = _userRepository.Login(credentials);

                if(user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenRepository.GenerateToken(user);

                user.Senha = "";

                return new
                {
                    user = user,
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
