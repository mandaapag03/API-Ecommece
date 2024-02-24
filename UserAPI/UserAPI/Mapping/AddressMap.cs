using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAPI.Model;

namespace UserAPI.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("endereco", "dbpet");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Cep)
                .HasColumnName("cep");

            builder.Property(e => e.Logradouro)
                .HasColumnName("logradouro");

            builder.Property(e => e.Numero)
                .HasColumnName("numero");

            builder.Property(e => e.Bairro)
                .HasColumnName("bairro");

            builder.Property(e => e.Cidade)
                .HasColumnName("cidade");

            builder.Property(e => e.Uf)
                .HasColumnName("uf");

            builder.Property(e => e.Complemento)
                .HasColumnName("complemento");

            builder.Property(e => e.UsuarioId)
                .HasColumnName("id_usuario");

            builder.HasOne(e => e.Usuario);
        }
    }
}
