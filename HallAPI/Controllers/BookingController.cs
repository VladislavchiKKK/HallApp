using HallApp.BusinessLogic.DTOs;
using HallApp.BusinessLogic.Exceptions;
using HallApp.BusinessLogic.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HallAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService bookingService;

    public BookingController(IBookingService bookingService)
    {
        this.bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingAsync([FromBody] CreateBookingDto dto)
    {
        try
        {
            decimal totalPrice = await bookingService.CreateBookingAsync(dto);
            return Ok($"Booked successfully with total price: {totalPrice}");
        }
        catch (HallAppException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
