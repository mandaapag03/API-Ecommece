using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model.Interfaces;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPedidoController : ControllerBase
    {
        private readonly StatusPedidoRepository _statusPedidoRepository;

        public StatusPedidoController() 
        {
            _statusPedidoRepository = new StatusPedidoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarStatusPedido()
        {
            try
            {
                return Ok(await _statusPedidoRepository.GetAll());
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
                return Ok(await _statusPedidoRepository.GetStatusPedido(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
