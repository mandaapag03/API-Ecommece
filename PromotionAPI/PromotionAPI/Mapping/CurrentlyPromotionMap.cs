using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromotionAPI.Model;

namespace PromotionAPI.Mapping
{
    public class CurrentlyPromotionMap : IEntityTypeConfiguration<CurrentlyPromotion>
    {
        public void Configure(EntityTypeBuilder<CurrentlyPromotion> builder)
        {
            builder.ToTable("promocoes_atuais", "dbpet");

            builder.HasKey(x => x.PromocaoId);
            builder.HasKey(x => x.ProdutoId);

            builder.Property(x => x.PromocaoId)
                .HasColumnName("id_promocao");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("id_produto");

            builder.HasOne(x => x.Promocao);
        }
    }
}
