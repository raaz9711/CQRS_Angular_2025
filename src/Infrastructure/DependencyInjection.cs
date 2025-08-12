using Application.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("Default")
                 ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default")
                 ?? "Server=localhost,1433;Database=CleanCqrsDemo;User Id=sa;Password=YourStrongPass123;TrustServerCertificate=True;";

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));
        services.AddScoped<IAppDbContext, AppDbContext>();
        return services;
    }
}
