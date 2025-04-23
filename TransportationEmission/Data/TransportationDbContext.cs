using Microsoft.EntityFrameworkCore;
using TransportationEmission.Models;

namespace TransportationEmission.Data
{
    public class TransportationDbContext : DbContext
    {
        public TransportationDbContext(DbContextOptions<TransportationDbContext> options) : base(options)
        {
            
        }

        public DbSet<TransportationEntity> transportationEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
