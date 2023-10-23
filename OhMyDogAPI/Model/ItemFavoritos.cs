using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OhMyDogAPI.Model
{
    public class ItemFavoritos
    {
        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        //Navigation Properties
        [Obsolete]
        public Usuario? Usuario { get; set; }

        [Obsolete]
        public Produto? Produto { get; set; }
    }
}
