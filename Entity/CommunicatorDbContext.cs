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
        public DbSet<Message> Messeges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().
                Property(r => r.Nick).
                IsRequired().
                HasMaxLength(25);
            modelBuilder.Entity<User>().
                HasIndex(r => r.Nick).
                IsUnique();
            modelBuilder.Entity<Chat>().
                Property(r => r.Name).
                IsRequired().
                HasMaxLength(50);
            modelBuilder.Entity<Message>().
                Property(r => r.Text).
                IsRequired().
                HasMaxLength(256);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
