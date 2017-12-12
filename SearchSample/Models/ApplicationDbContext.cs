using System.Data.Entity;

namespace SearchSample.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Search> Searches { get; set; }
        public DbSet<Click> Clicks { get; set; }
    }
}