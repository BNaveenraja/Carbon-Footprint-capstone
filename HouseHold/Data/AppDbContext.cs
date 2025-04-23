
using HouseHold.Models;
using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;

namespace HouseHold.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<HouseHoldEntity> HouseHoldEntities { get; set; }
    }
}
