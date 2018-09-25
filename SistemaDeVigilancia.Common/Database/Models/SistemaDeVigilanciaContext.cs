using Microsoft.EntityFrameworkCore;
using System;

namespace SistemaDeVigilancia.Common.Database.Models
{
    public class SistemaDeVigilanciaContext : DbContext
    {
        public SistemaDeVigilanciaContext(DbContextOptions<SistemaDeVigilanciaContext> options)
            : base(options)
        { }

        public DbSet<Ping> Pings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VpnUser> VpnUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ping>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<VpnUser>().HasKey(x => x.Id);
        }
    }
}
