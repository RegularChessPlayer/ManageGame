using ManageGameApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageGameApi.Domain.Configuration
{
    public class UserManageConfiguration : IEntityTypeConfiguration<UserManage>
    {
        public void Configure(EntityTypeBuilder<UserManage> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(255).IsRequired();
            builder.Property(u => u.Password).HasColumnName("password").HasMaxLength(8).IsRequired();
            builder.Property(u => u.Role).HasColumnName("role").HasMaxLength(50).IsRequired();

            builder.HasMany<Friend>(u => u.Friends)
                .WithOne(u => u.UserManage)
                .HasForeignKey(u => u.UserManageId);

            builder.HasMany<Game>(u => u.Games)
                .WithOne(u => u.UserManage)
                .HasForeignKey(u => u.UserManageId);

            builder.HasMany<LocateGame>(u => u.LocateGames)
                .WithOne(u => u.UserManage)
                .HasForeignKey(u => u.UserManageId);

        }
    }
}
