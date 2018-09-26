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
        public DbSet<MovementDetection> MovementDetections { get; set; }
    }
}
