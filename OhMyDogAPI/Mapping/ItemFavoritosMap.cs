using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class ItemFavoritosMap : IEntityTypeConfiguration<ItemFavoritos>
    {
        public void Configure(EntityTypeBuilder<ItemFavoritos> builder)
        {
            builder.ToTable("favoritos", "dbpet");

            builder.HasKey(ic => ic.UsuarioId);
            builder.HasKey(ic => ic.ProdutoId);

            builder.Property(ic => ic.UsuarioId)
                .HasColumnName("id_usuario");

            builder.Property(ic => ic.ProdutoId)
                .HasColumnName("id_produto");

            builder.HasOne(ic => ic.Usuario);
            builder.HasOne(ic => ic.Produto);
        }
    }
}
