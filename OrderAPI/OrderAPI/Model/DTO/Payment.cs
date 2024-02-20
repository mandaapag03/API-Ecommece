using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Model
{
    public class Payment
    {
        [Obsolete]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Obsolete]
        [ForeignKey("StatusPagamento")]
        public int StatusPagamentoId { get; set; }

        [ForeignKey("FormaPagamento")]
        public int FormaPagamentoId { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        public int QuantidadeParcelas { get; set; }

        public double Total { get; set; }

        // Navigation Properties

    }
}
