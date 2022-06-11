using GoldBusinessManagementApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldBusinessManagementApp.Database.DBConfig
{
    public class GoldBusinessManagementDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "workstation id=GoldBusinessManagementDb.mssql.somee.com;packet size=4096;user id=sunilkarmakar_SQLLogin_1;pwd=yr3357udu8;data source=GoldBusinessManagementDb.mssql.somee.com;persist security info=False;initial catalog=GoldBusinessManagementDb";

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
