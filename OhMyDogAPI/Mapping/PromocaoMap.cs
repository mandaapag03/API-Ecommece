using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class PromocaoMap : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("promocao", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Nome)
                .HasColumnName("nome");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao");

            builder.Property(x => x.Desconto)
                .HasColumnName("desconto");
        }
    }
}
