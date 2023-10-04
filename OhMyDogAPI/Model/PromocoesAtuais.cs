using System.ComponentModel.DataAnnotations.Schema;

namespace OhMyDogAPI.Model
{
    public class PromocoesAtuais
    {
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("Promocao")]
        public int PromocaoId { get; set; }

        // Navigation Properties
        [Obsolete]
        public Produto? Produto { get; set; }
        [Obsolete]
        public Promocao? Promocao { get; set; }
    }
}
