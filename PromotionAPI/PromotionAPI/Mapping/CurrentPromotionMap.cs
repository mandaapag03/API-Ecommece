using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromotionAPI.Model;

namespace PromotionAPI.Mapping
{
    public class CurrentPromotionMap : IEntityTypeConfiguration<CurrentPromotion>
    {
        public void Configure(EntityTypeBuilder<CurrentPromotion> builder)
        {
            builder.ToTable("promocoes_atuais", "dbpet");

            builder.HasKey(x => x.PromocaoId);
            builder.HasKey(x => x.ProdutoId);

            builder.Property(x => x.PromocaoId)
                .HasColumnName("id_promocao");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("id_produto");
        }
    }
}
