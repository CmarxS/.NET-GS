using Microsoft.EntityFrameworkCore;
using FloodianGlobal.Entities;

namespace FloodianGlobal.Data
{
    public class FloodianDbContext : DbContext
    {
        public FloodianDbContext(DbContextOptions<FloodianDbContext> options) : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
