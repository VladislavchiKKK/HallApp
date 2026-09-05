namespace HallApp.BusinessLogic.Interfaces.ServiceInterfaces;

public interface IPricingService
{
    decimal CalculateTotalPrice(DateTime startDateTime, DateTime endDateTime, decimal pricePerHour);
}
