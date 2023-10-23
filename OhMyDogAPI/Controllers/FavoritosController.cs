using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model.Interfaces;
using OhMyDogAPI.Model;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly FavoritosRepository _favoritosRepository;
        public FavoritosController()
        {
            _favoritosRepository = new FavoritosRepository();
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult> BuscarCarrinho([FromRoute] int idUsuario)
        {
            try
            {
                var result = await _favoritosRepository.GetFavoritos(idUsuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("item/adicionar")]
        public async Task<ActionResult> AdicionarItemAoCarrinho([FromBody] ItemFavoritos item)
        {
            try
            {
                var result = await _favoritosRepository.AddItemToFavoritos(item);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("item/excluir")]
        public async Task<IActionResult> ExcluirItemDoCarrinho([FromBody] ItemFavoritos item)
        {
            try
            {
                var result = await _favoritosRepository.DeleteItemFromFavoritos(item);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

