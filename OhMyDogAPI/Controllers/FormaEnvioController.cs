using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaEnvioController : ControllerBase
    {
        private FormaEnvioRepository _formaEnvioRepository;

        public FormaEnvioController()
        {
            _formaEnvioRepository = new FormaEnvioRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarFormasEnvio()
        {
            try
            {
                return Ok(await _formaEnvioRepository.GetAllFormasEnvio());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFormaEnvio(int id)
        {
            try
            {
                return Ok(await _formaEnvioRepository.GetFormaEnvio(id));
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
    }
}
