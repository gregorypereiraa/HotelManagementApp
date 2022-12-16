using DataLibrary.Dtos.Booking;
using DataLibrary.Models;
using DataLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var bookings = await _bookingService.GetAllAsync();
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] BookingEntryDto booking)
    {
        await _bookingService.CreateAsync(booking);
        return NoContent();
    }
}