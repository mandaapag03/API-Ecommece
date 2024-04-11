using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionAPI.Model
{
    public class CurrentPromotion
    {
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("Promocao")]
        public int PromocaoId { get; set; }
    }
}
