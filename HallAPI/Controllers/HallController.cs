using HallApp.BusinessLogic.DTOs;
using HallApp.BusinessLogic.Exceptions;
using HallApp.BusinessLogic.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HallAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HallController : ControllerBase
{
    private readonly IHallService hallService;

    public HallController(IHallService hallService)
    {
        this.hallService = hallService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateHallAsync([FromBody] HallDto hallDto)
    {
        try
        {
            int hallId = await hallService.CreateHallModelAsync(hallDto);
            return Ok(hallId);
        }
        catch (HallAppException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHallByIdAsync([FromRoute] int id) 
    {
        try
        {
            await hallService.DeleteHallByIdAsync(id);
            return Ok("Deleted hall successfully");
        }
        catch (HallAppException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHallAsync([FromBody] HallDto hallDto, [FromRoute] int id)
    {
        try
        {
            await hallService.UpdateHallAsync(hallDto, id);
            return Ok("Updated hall successfully");
        }
        catch (HallAppException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("searchHalls")]
    public async Task<IActionResult> SearchHallsAsync([FromQuery] int capacity, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        try
        {
            FilterHallsDto filterHallsDto = new FilterHallsDto
            {
                Capacity = capacity,
                StartDate = startDate,
                EndDate = endDate
            };

            ICollection<HallDto> halls = await hallService.SearchAvailableHallsAsync(filterHallsDto);
            return Ok(halls);
        }
        catch (HallAppException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
