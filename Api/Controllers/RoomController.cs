using DataLibrary.Dtos.Room;
using DataLibrary.Models;
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
}