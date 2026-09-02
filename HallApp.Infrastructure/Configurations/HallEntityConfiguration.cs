using HallApp.Entities.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HallApp.Infrastructure.Configurations;

public class HallEntityConfiguration : IEntityTypeConfiguration<HallEntity>
{
    public void Configure(EntityTypeBuilder<HallEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).IsRequired();

        builder.HasMany(h => h.ServiceEntities)
               .WithMany(s => s.HallEntities);

        builder.HasData(
            new HallEntity { Id = 1, Name = "Hall A", Capacity = 50, PricePerHour = 2000 },
            new HallEntity { Id = 2, Name = "Hall B", Capacity = 100, PricePerHour = 3500 },
            new HallEntity { Id = 3, Name = "Hall C", Capacity = 30, PricePerHour = 1500 }
        );
    }
}
