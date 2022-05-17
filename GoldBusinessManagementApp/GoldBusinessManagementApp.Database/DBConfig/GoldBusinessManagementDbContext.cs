using GoldBusinessManagementApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldBusinessManagementApp.Database.DBConfig
{
    public class GoldBusinessManagementDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                        Initial Catalog = GoldBusinessManagementDb;
                                        Integrated Security = True";

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
