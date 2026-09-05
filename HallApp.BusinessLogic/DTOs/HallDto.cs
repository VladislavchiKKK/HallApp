namespace HallApp.BusinessLogic.DTOs;

public class HallDto
{
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal PricePerHour { get; set; }

    public ICollection<int> ServiceIds { get; set; } = [];
}
