using InventoryAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAPI.Mapping
{
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("estoque", "dbpet");

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId)
                .HasColumnName("id_produto");
                        
            builder.Property(x => x.Quantity)
                .HasColumnName("quantidade");
        }
    }
}
