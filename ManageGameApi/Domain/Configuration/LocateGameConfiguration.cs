using ManageGameApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ManageGameApi.Domain.Configuration
{
    public class LocateGameConfiguration : IEntityTypeConfiguration<LocateGame>
    {
        public void Configure(EntityTypeBuilder<LocateGame> builder)
        {
            builder.HasKey(l => new { l.GameId, l.FriendId});

        }
    }
}
