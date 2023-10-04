using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private PromocaoRepository _promocaoRepository;

        public PromocaoController()
        {
            _promocaoRepository = new PromocaoRepository();
        }

        [HttpGet]
        public async Task<IActionResult> ListarPromocoes()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPromocao()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPromocao([FromBody] Promocao promocao)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPromocao(int id)
        {
            throw new NotImplementedException();
        }
    }
}
