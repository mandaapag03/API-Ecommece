using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "dbpet");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.TipoUsuarioId)
                .HasColumnName("id_tipo_usuario");

            builder.Property(e => e.Cpf)
                .HasColumnName("cpf");

            builder.Property(e => e.NomeCompleto)
                .HasColumnName("nome_completo");

            builder.Property(e => e.Email)
                .HasColumnName("email");

            builder.Property(e => e.Senha)
                .HasColumnName("senha");

            builder.Property(e => e.Telefone)
                .HasColumnName("telefone");

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active");

            builder.HasOne(e => e.TipoUsuario);
        }
    }
}
