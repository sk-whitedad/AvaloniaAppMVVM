using AvaloniaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaDB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies => Set<Company>();

        public ApplicationDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AvaloniaDB.db");
        }

    }
}
