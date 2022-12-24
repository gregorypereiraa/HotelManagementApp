using DataLibrary.Dtos.Room;
using DataLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var rooms = await _roomService.GetAllAsync();
        return Ok(rooms);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RoomEntryDto room)
    {
        await _roomService.CreateAsync(room);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _roomService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] RoomEntryDto room)
    {
        await _roomService.UpdateAsync(id, room);
        return NoContent();
    }

    [HttpGet("Available/{from:datetime}/{to:datetime}")]
    public async Task<ActionResult> GetAvailable(DateTime from, DateTime to)
    {
        var roomsAvailable = await _roomService.GetRoomAvailableAsync(from, to);
        return Ok(roomsAvailable);
    }
}