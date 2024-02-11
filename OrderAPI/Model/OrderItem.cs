using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Model
{
    public class OrderItem
    {
        [Obsolete]
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        // Navigation Properties
        [Obsolete]
        public Order? Pedido { get; set; }
    }
}
