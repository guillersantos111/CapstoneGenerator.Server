using Microsoft.EntityFrameworkCore;
using CapstoneGenerator.Server.Data.Configurations;
using CapstoneGenerator.Server.Models;

namespace CapstoneGenerator.Server.Data.DbContext
{
    public class WebApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WebApplicationDbContext(DbContextOptions<WebApplicationDbContext> options) : base(options) { }

        public DbSet<Capstones> Capstones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CapstoneConfig());
        }
    }
}
