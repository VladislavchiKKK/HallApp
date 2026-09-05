namespace HallApp.Entities.DatabaseEntities;

public class BookingEntity : BaseEntity
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }

    public int HallId { get; set; }

    public HallEntity? HallEntity { get; set; }

    public ICollection<ServiceEntity> ServiceEntities { get; set; } = [];
}
