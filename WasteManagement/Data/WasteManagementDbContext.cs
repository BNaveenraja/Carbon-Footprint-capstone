using EcoLife.WasteManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using WasteManagement.Models;

namespace EcoLife.WasteManagementApi.Data
{
    public class WasteManagementDbContext : DbContext
    {

        public WasteManagementDbContext(DbContextOptions<WasteManagementDbContext> options) : base(options)
        {

        }

        public DbSet<WasteManagementEntity> WasteManagementEntities { get; set; }
    }
}
