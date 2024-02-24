using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Model;

namespace ProductAPI.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categoria", "dbpet");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
                .HasColumnName("nome_categoria");

            builder.Property(c => c.IdSubCategoria)
                .HasColumnName("id_subcategoria");

            builder.HasOne(c => c.SubCategoria);
        }
    }
}
