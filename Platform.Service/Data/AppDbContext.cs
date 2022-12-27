using Microsoft.EntityFrameworkCore;
using Platform.Service.Models;

namespace Platform.Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<PlatForm> Platforms { get; set; }
    }
}
