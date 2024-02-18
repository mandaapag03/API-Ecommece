using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Model
{
    public class Order
    {
        [Obsolete]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Obsolete]
        [ForeignKey("StatusPedido")]
        public int StatusPedidoId { get; set; }

        [ForeignKey("FormaEnvio")]
        public int FormaEnvioId { get; set; }

        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }

        [Obsolete]
        public DateOnly DataPedido { get; set; }

        // Navigation Properties
        [Obsolete]
        public OrderStatus? StatusPedido { get; set; }
        [Obsolete]
        public Shipping? FormaEnvio { get; set; }
    }
}
