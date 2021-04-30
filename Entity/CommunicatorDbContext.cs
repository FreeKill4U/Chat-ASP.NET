using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.Entity
{
    public class CommunicatorDbContext : DbContext
    {
        private readonly string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=CommunicatorDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Messege> Messeges { get; set; }
        public DbSet<Rank> Ranks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(r => r.Nick).
                IsRequired().
                HasMaxLength(25);
            modelBuilder.Entity<Chat>().
                Property(r => r.Name).
                IsRequired().
                HasMaxLength(50);
            modelBuilder.Entity<Rank>().
                Property(r => r.Name).
                IsRequired().
                HasMaxLength(25);
            modelBuilder.Entity<Messege>().
                Property(r => r.Text).
                IsRequired().
                HasMaxLength(256);
            modelBuilder.Entity<Rank>().
                Property(r => r.Name).
                IsRequired().
                HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
