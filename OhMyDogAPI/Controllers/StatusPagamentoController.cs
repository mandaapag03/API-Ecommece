using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPagamentoController : ControllerBase
    {
        private readonly StatusPagamentoRepository _statusPagamentoRepository;
        public StatusPagamentoController()
        {
            _statusPagamentoRepository = new StatusPagamentoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarStatusPedido()
        {
            try
            {
                return Ok(await _statusPagamentoRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCategoria(int id)
        {
            try
            {
                return Ok(await _statusPagamentoRepository.GetStatusPagamento(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
