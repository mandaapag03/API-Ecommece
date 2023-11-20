using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("id_usuario");
            
            builder.Property(x => x.StatusPedidoId)
                .HasColumnName("id_status_pedido");

            builder.Property(x => x.FormaEnvioId)
                .HasColumnName("id_forma_envio");
            
            builder.Property(x => x.EnderecoId)
                .HasColumnName("id_endereco");

            builder.Property(x => x.DataPedido)
                .HasColumnName("data_pedido");

            builder.HasOne(x => x.StatusPedido);
            builder.HasOne(x => x.FormaEnvio);
            builder.HasOne(x => x.Usuario);
            builder.HasOne(x => x.Endereco);
        }
    }
}

