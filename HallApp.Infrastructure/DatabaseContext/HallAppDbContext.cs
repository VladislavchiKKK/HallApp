using HallApp.Entities.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace HallApp.Infrastructure.DatabaseContext;

public class HallAppDbContext : DbContext
{
    public HallAppDbContext(DbContextOptions<HallAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HallAppDbContext).Assembly);
    }

    public DbSet<HallEntity> HallEntities { get; set; }

    public DbSet<ServiceEntity> ServiceEntities { get; set; }
}

