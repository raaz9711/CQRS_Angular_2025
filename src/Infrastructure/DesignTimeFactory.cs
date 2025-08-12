using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class DesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var cfg = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(cfg.GetConnectionString("Default") ??
                          "Server=localhost,1433;Database=CleanCqrsDemo;User Id=sa;Password=YourStrongPass123;TrustServerCertificate=True;")
            .Options;

        return new AppDbContext(options);
    }
}
    