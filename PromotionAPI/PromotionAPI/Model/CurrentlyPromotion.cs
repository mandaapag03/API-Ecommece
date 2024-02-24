using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionAPI.Model
{
    public class CurrentlyPromotion
    {
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("Promocao")]
        public int PromocaoId { get; set; }

        // Navigation Properties
        [Obsolete]
        public Promotion? Promocao { get; set; }
    }
}
