namespace HallApp.BusinessLogic.DTOs;

public class FilterHallsDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Capacity { get; set; }
}
