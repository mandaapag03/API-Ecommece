﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OhMyDogAPI.Model;

namespace OhMyDogAPI.Mapping
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("pagamento", "dbpet");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("id_usuario");
            
            builder.Property(x => x.StatusPagamentoId)
                .HasColumnName("id_status");

            builder.Property(x => x.FormaPagamentoId)
                .HasColumnName("id_forma_pagamento");
            
            builder.Property(x => x.PedidoId)
                .HasColumnName("id_pedido");

            builder.Property(x => x.QuantidadeParcelas)
                .HasColumnName("qtd_parcelas");

            builder.Property(x => x.Total)
                .HasColumnName("total");

            builder.HasOne(x => x.StatusPagamento);
            builder.HasOne(x => x.FormaPagamento);
            builder.HasOne(x => x.Usuario);
            builder.HasOne(x => x.Pedido);
        
        }
    }
}
