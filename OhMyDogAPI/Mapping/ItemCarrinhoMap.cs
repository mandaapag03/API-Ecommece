using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class ItemCarrinhoMap : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.ToTable("carrinho", "dbpet");

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
