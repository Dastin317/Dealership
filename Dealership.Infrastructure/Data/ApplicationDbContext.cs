using Microsoft.EntityFrameworkCore;
using SecondHandDealership.Models;

namespace DealershipManager.Data
{
    // ApplicationDbContext = abstractizarea bazei de date
    public class ApplicationDbContext : DbContext
    {
        // Abstractizarea tabelului CARS din SQL Database
        public DbSet<Car> Cars { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
