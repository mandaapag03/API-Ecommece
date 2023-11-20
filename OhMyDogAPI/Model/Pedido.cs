using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class Pedido
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
        public StatusPedido? StatusPedido { get; set; }
        [Obsolete]
        public FormaEnvio? FormaEnvio { get; set; }
        [Obsolete]
        public Usuario? Usuario { get; set; }
        [Obsolete]
        public Endereco? Endereco { get; set; }
    }
}
