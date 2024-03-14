using GaB_Auth.DbConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace GaB_Auth.DbConnector;

public class ApplicationContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // заполнять типы если они не заполнены https://metanit.com/sharp/efcore/2.14.php
        //modelBuilder.Entity<PaymentTariff>().HasData(
        //    new PaymentTariff { },
        //    new PaymentTariff { }
        //);
    }
}