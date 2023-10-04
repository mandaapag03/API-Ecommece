using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class PromocoesAtuaisMap : IEntityTypeConfiguration<PromocoesAtuais>
    {
        public void Configure(EntityTypeBuilder<PromocoesAtuais> builder)
        {
            builder.ToTable("promocoes_atuais", "dbpet");

            builder.HasKey(x => x.PromocaoId);
            builder.HasKey(x => x.ProdutoId);

            builder.Property(x => x.PromocaoId)
                .HasColumnName("id_promocao");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("id_produto");

            builder.HasOne(x => x.Promocao);
            builder.HasOne(x => x.Produto);
        }
    }
}
