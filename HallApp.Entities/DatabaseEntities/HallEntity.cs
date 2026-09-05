namespace HallApp.Entities.DatabaseEntities;

public class HallEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal PricePerHour { get; set; }

    public ICollection<ServiceEntity> ServiceEntities { get; set; } = [];
}
