using DataLibrary.Dtos.RoomType;
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
    public async Task<ActionResult> Post([FromBody] RoomTypeEntryDto roomType)
    {
        await _roomTypesService.CreateAsync(roomType);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _roomTypesService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] RoomTypeEntryDto roomType)
    {
        await _roomTypesService.UpdateAsync(id, roomType);
        return NoContent();
    }
}