using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "dbpet");
            builder.HasKey(p => p.Id);

            // utilizado na geração de PK em bancos criados por ORM
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(p => p.Nome)
                .HasColumnName("nome_produto");

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao");

            builder.Property(p => p.Foto)
                .HasColumnName("foto");

            builder.Property(p => p.PrecoUnitario)
                .HasColumnName("preco_unitario");

            builder.Property(p => p.IsActive)
                .HasColumnName("is_active");

            builder.Property(p => p.CategoriaId)
                .HasColumnName("id_categoria");

            builder.HasOne(p => p.Categoria);
        }
    }
}
