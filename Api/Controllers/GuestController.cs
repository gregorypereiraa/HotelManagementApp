using DataLibrary.Dtos.Guest;
using DataLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var guests = await _guestService.GetAllAsync();
        return Ok(guests);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] GuestEntryDto guest)
    {
        var id = await _guestService.CreateAsync(guest);
        return Ok(id);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _guestService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] GuestEntryDto guest)
    {
        await _guestService.UpdateAsync(id, guest);
        return NoContent();
    }
}