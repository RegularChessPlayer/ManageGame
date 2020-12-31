using ManageGameApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ManageGameApi.Domain.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(g => g.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        }
    }
}
