using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Model
{
    public class CartItem
    {
        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        //Navigation Properties
    }
}
