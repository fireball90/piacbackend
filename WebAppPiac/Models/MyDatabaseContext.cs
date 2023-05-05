using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAppPiac.Models;
using System;

namespace WebAppPiac.Data
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() { }
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Gyumolcs> Gyumolcs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=piac2;user=root;password=;ssl mode=none;");
            }
        }
    }
}
