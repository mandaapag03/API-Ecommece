using AdministratorAPI.Model;
using AdministratorAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AdministratorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackController() 
        { 
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetAll()
        {
            try
            {
                return Ok(await _feedbackRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetById(int id)
        {
            try
            {
                return Ok(await _feedbackRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("send")]
        public async Task<ActionResult<Feedback>> Send([FromBody] Feedback feedback)
        {
            try
            {
                return Ok(await _feedbackRepository.Send(feedback));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
