using HallApp.BusinessLogic.Interfaces.ServiceInterfaces;

namespace HallApp.BusinessLogic.Services;

public class PricingService : IPricingService
{
    public decimal CalculateTotalPrice(DateTime startDateTime, DateTime endDateTime, decimal pricePerHour)
    {
        decimal totalCost = 0;
        DateTime current = startDateTime;

        while (current < endDateTime)
        {
            int hour = current.Hour;
            decimal percentage = GetPercentageForHour(hour);

            totalCost += pricePerHour * percentage;
            current = current.AddHours(1);
        }

        return totalCost;
    }

    private static decimal GetPercentageForHour(int hour)
    {
        if (hour >= 12 && hour < 14)
        {
            return 1.15m;
        }

        if (hour >= 9 && hour < 18)
        {
            return 1m;
        }

        if (hour >= 6 && hour < 9)
        {
            return 0.9m;
        }

        if (hour >= 18 && hour < 23)
        {
            return 0.8m;
        }

        return 1m;
    }
}
