using DevSkill.Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSkill.Shop.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<SeriLog> SeriLogs { get; set; }

    }
}
