using Microsoft.EntityFrameworkCore;
using TechApi.Database.DBModels;

namespace TechApi.Database.Context
{
    public class TechApiContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PRM8AD3;Database=DualTechBD;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().Property(policy => policy.SumAssured).HasPrecision(18, 2);
            modelBuilder.Entity<ExchangeRate>().Property(exchange => exchange.Rate).HasPrecision(18, 4);
            modelBuilder.Entity<ExchangeRate>().Property(exchange => exchange.InitialDate).HasColumnType("date");
            modelBuilder.Entity<ExchangeRate>().Property(exchange => exchange.FinalDate).HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }
}