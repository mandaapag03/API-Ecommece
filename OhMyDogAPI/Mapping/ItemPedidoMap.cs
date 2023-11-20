using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("item_pedido", schema: "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.PedidoId)
                .HasColumnName("id_pedido");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("id_produto");

            builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade");

            builder.HasOne(x => x.Pedido);
            builder.HasOne(x => x.Produto);

        }
    }
}
