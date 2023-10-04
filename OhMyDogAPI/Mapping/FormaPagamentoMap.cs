using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class FormaPagamentoMap : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("forma_pagamento", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao");
        }
    }
}
