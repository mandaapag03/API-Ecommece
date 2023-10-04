using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagamentoController : ControllerBase
    {
        private FormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoController()
        {
            _formaPagamentoRepository = new FormaPagamentoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarFormasPagamento()
        {
            try
            {
                return Ok(await _formaPagamentoRepository.GetAllFormasPagamento());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFormaPagamento(int id)
        {
            try
            {
                return Ok(await _formaPagamentoRepository.GetFormaPagamento(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
