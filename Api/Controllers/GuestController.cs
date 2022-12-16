using DataLibrary.Models;
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
    public async Task<ActionResult> Post([FromBody] Guest guest)
    {
        await _guestService.CreateAsync(guest);
        return NoContent();
    }
}