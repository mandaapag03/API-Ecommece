using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Model;

namespace OrderAPI.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
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
        }
    }
}
