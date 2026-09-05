namespace HallApp.Entities.DatabaseEntities;

public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public ICollection<HallEntity> HallEntities { get; set; } = [];
}
