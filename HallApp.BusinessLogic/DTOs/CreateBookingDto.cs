namespace HallApp.BusinessLogic.DTOs;

public class CreateBookingDto
{
    public int HallId { get; set; }

    public DateTime StartDateTime { get; set; }

    public int DurationHours { get; set; }

    public ICollection<int> ServiceIds { get; set; } = [];
}
