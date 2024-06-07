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
        public async Task<ActionResult<User>> ListUsers()
        {
            try
            {
                return Ok(await _userRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("findById/{id}")]
        public async Task<ActionResult<User>> FindUserByID(int id)
        {
            try
            {
                return Ok(await _userRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("find/{cpf}")]
        public async Task<ActionResult<User>> FindUserByCpf(string cpf)
        {
            try
            {
                return Ok(await _userRepository.GetByCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            try
            {
                return Ok(await _userRepository.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<User>> Update(User user)
        {
            try
            {
                return Ok(await _userRepository.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inactivate/{id}")]
        public async Task<ActionResult<User>> Inactivate(int id)
        {
            try
            {
                return Ok(await _userRepository.Disable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reactivate/{id}")]
        public async Task<ActionResult<User>> Reactivate(int id)
        {
            try
            {
                return Ok(await _userRepository.Enable(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<dynamic> Login(Credentials credentials)
        {
            try
            {
                var user = await _userRepository.Login(credentials);

                if (user == null)
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
