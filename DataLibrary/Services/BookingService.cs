using AutoMapper;
using DataLibrary.Dtos.Booking;
using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class BookingService : IBookingService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public BookingService(ApplicationDbContext db,IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var bookings = await _db.Bookings
            .Include(x => x.Room)
            .ThenInclude(x => x.RoomType)
            .ToListAsync();

        var bookingsDto = bookings.Select(x => _mapper.Map<BookingDto>(x));
        return bookingsDto;
    }

    public async Task CreateAsync(BookingEntryDto booking)
    {

        var entry = new Booking()
        {
            Start = booking.Start,
            End = booking.End,
            RoomsId = booking.RoomId,
            GuestId = booking.GuestId

        };
        _db.Bookings.Add(entry);
        await _db.SaveChangesAsync();
    }
}