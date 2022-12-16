using DataLibrary.Models;
using DataLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomTypesController : ControllerBase
{
    private readonly IRoomTypesService _roomTypesService;

    public RoomTypesController(IRoomTypesService roomTypesService)
    {
        _roomTypesService = roomTypesService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var roomTypes = await _roomTypesService.GetAllAsync();
        return Ok(roomTypes);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RoomType roomType)
    {
        await _roomTypesService.CreateAsync(roomType);
        return NoContent();
    }
}