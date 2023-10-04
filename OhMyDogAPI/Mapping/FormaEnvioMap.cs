using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class FormaEnvioMap : IEntityTypeConfiguration<FormaEnvio>
    {
        public void Configure(EntityTypeBuilder<FormaEnvio> builder)
        {
            builder.ToTable("forma_envio", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao");

            builder.Property(x => x.ValorFrete)
                .HasColumnName("valor_frete");
        }
    }
}
