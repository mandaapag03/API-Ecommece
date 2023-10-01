using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class ItemCarrinho
    {
        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        //Navigation Properties
        [Obsolete]
        public Usuario? Usuario { get; set;}
        
        [Obsolete]
        public Produto? Produto { get; set; }
    }
}
