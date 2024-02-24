using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Model;

namespace OrderAPI.Mapping
{
    public class ShippingMap : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
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
