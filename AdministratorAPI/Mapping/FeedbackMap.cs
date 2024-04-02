using AdministratorAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministratorAPI.Mapping
{
    public class FeedbackMap : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedback", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Nota)
                .HasColumnName("nota");

            builder.Property(x => x.Comentario)
                .HasColumnName("comentario");
        }
    }
}
