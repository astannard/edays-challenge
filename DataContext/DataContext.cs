using System;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Filename=./StartYourEday.db");

        public DbSet<MessageOfTheDay> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageOfTheDay>()
                .HasIndex(p => new { p.ShowOn })
                .IsUnique(true);
        }
    }
}
