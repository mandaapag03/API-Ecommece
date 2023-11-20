using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class Pagamento
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
        [Obsolete]
        public StatusPagamento? StatusPagamento { get; set; }
        [Obsolete]
        public FormaPagamento? FormaPagamento { get; set; }
        [Obsolete]
        public Usuario? Usuario { get; set; }
        [Obsolete]
        public Pedido? Pedido { get; set; }

    }
}
