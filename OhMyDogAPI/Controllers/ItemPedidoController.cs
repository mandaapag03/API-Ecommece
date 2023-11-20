using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OhMyDogAPI.Model.Interfaces;
using OhMyDogAPI.Repository;

namespace OhMyDogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController()
        {
            _itemPedidoRepository = new ItemPedidoRepository();
        }

        [HttpGet("{idPedido}")]
        public async Task<ActionResult> ListarItensPorPedido(int pedidoId)
        {
            try
            {
                return Ok(await _itemPedidoRepository.GetAll(pedidoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idPedido}/{idItem}")]
        public async Task<ActionResult> BuscarItemPorPedido([FromQuery]int pedidoId, [FromQuery] int itemId)
        {
            try
            {
                return Ok(await _itemPedidoRepository.GetItemWithPedidoId(pedidoId, itemId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
