using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class ItemCarrinho
    {
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        //Navigation Properties
        public Usuario? Usuario { get; set;}
        public Produto? Produto { get; set; }
    }
}
