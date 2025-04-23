using HouseHoldEmission.Model;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldEmission.Data
{
    public class HouseHoldDbContext : DbContext
    {
        public HouseHoldDbContext(DbContextOptions<HouseHoldDbContext> options) : base(options)
        {
            
        }

        public DbSet<HouseHoldEntity> HouseHoldEntities { get; set; }
    }
}
