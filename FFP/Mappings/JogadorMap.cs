﻿using FFP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FFP.Mappings
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogadores");

            builder.Property(p => p.Nome).HasColumnType("varchar(100)");
            builder.Property(p => p.Posicao).HasColumnType("varchar(100)");
            builder.Property(p => p.PeDominante).HasColumnType("varchar(100)");
            builder.Property(p => p.Idade).HasColumnType("int");
            builder.Property(p => p.Endereco).HasColumnType("varchar(100)");

            builder.HasOne(p => p.Time)
                .WithMany(p => p.Jogadores)
                .HasForeignKey(p => p.TimeID);
        }
    }
}