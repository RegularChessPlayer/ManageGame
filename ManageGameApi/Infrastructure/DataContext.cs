using ManageGameApi.Domain.Configuration;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ManageGameApi.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<UserManage> UserManage { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<LocateGame> LocateGame { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserManageConfiguration());
            modelBuilder.ApplyConfiguration(new FriendConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new LocateGameConfiguration());

            modelBuilder.Entity<UserManage>().HasData
             (
                 new UserManage
                 {
                     Id = 100,
                     Email = "admin",
                     Password = "admin",
                     Role = "admin",
                 }
            );

           

            modelBuilder.Entity<Friend>().HasData
            (
                new Friend { Id = 90, Name = "Jhon Dean", UserManageId = 100 },
                new Friend { Id = 91, Name = "Derick Jhonson", UserManageId = 100 }
            );

            modelBuilder.Entity<Game>().HasData
            (
                new Game { Id = 100, Name = "God of War", UserManageId = 100 },
                new Game { Id = 101, Name = "Derick Jhonson", UserManageId = 100 }
            );

            modelBuilder.Entity<LocateGame>().HasData
            (
                 new LocateGame { FriendId = 90, GameId = 100, UserManageId = 100 }
            );

            modelBuilder.LowercaseRelationalTableAndPropertyNames();

        }

    }
}
