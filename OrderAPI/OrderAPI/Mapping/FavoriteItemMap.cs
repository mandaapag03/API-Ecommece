using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Model;

namespace OrderAPI.Mapping
{
    public class FavoriteItemMap : IEntityTypeConfiguration<FavoriteItem>
    {
        public void Configure(EntityTypeBuilder<FavoriteItem> builder)
        {
            builder.ToTable("favoritos", "dbpet");

            builder.HasKey(ic => ic.UsuarioId);
            builder.HasKey(ic => ic.ProdutoId);

            builder.Property(ic => ic.UsuarioId)
                .HasColumnName("id_usuario");

            builder.Property(ic => ic.ProdutoId)
                .HasColumnName("id_produto");
        }
    }
}
