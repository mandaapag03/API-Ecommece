using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Model;

namespace OrderAPI.Mapping
{
    public class RatingMap : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("avaliacao", schema: "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("id_usuario");

            builder.Property(x => x.ProdutoId)
                .HasColumnName("id_produto");
            
            builder.Property(x => x.Nota)
                .HasColumnName("nota");
            
            builder.Property(x => x.Comentario)
                .HasColumnName("comentario");
        }
    }
}
