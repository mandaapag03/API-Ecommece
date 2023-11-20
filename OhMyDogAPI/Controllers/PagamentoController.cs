using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoRepository _pagamentoRepository;

        public PagamentoController()
        {
            _pagamentoRepository = new PagamentoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarPagamentos() 
        {
            try
            {
                return Ok(await _pagamentoRepository.GetAllPagamentos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        
        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> ListarPagamentosUsuario(int idUsuario) 
        {
            try
            {
                return Ok(await _pagamentoRepository.GetPagamentosFromUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("pedido/{idPedido}")]
        public async Task<IActionResult> ListarPagamentosPedido(int idPedido) 
        {
            try
            {
                return Ok(await _pagamentoRepository.GetPagamentosFromPedido(idPedido));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPagamento(int id) 
        {
            try
            {
                return Ok(await _pagamentoRepository.GetPagamento(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> CancelarPagamento(int id) 
        {
            try
            {
                return Ok(await _pagamentoRepository.CancelarPagamento(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
