﻿using FFP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FFP.Mappings
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable("Times");

            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Bairro).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Fundacao).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.Presidente).HasColumnType("varchar(100)").IsRequired();

            builder.HasMany(p => p.Jogadores)
                .WithOne(p => p.Time)
                .HasPrincipalKey(p => p.JogadorID);
        }
    }
}
