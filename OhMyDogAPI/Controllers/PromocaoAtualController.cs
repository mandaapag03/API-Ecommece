using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoAtualController : ControllerBase
    {
        private readonly PromocoesAtuaisRepository _promocoesAtuaisRepository;
        public PromocaoAtualController()
        {
            _promocoesAtuaisRepository = new PromocoesAtuaisRepository();
        }


    }
}
