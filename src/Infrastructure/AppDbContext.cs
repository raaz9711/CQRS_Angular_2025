// src/Infrastructure/AppDbContext.cs
using Application.Common.Abstractions;   // ✅ important
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext, IAppDbContext   // ✅ implements
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}
