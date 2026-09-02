using HallApp.Entities.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HallApp.Infrastructure.Configurations;

public class ServiceEntityConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired();

        builder.HasMany(s => s.HallEntities)
               .WithMany(h => h.ServiceEntities);

        builder.HasData(
            new ServiceEntity { Id = 1, Name = "Projector", Price = 500 },
            new ServiceEntity { Id = 2, Name = "Wi-Fi", Price = 300 },
            new ServiceEntity { Id = 3, Name = "Sound", Price = 700 }
        );
    }
}
