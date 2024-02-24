using Microsoft.AspNetCore.Mvc;
using PromotionAPI.Repository;

namespace PromotionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentlyPromotionController : ControllerBase
    {
        private readonly CurrentlyPromotionRepository _currentlyPromotionRepository;
        public CurrentlyPromotionController()
        {
            _currentlyPromotionRepository = new CurrentlyPromotionRepository();
        }


    }
}
