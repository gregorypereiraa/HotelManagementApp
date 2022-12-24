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

    public BookingService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        var bookings = await _db.Bookings
            .Include(x => x.Room)
            .ThenInclude(x => x.RoomType)
            .Include(x => x.Guest)
            .ToListAsync();

        var bookingsDto = bookings.Select(x => _mapper.Map<BookingDto>(x));
        return bookingsDto;
    }

    public async Task CreateAsync(BookingEntryDto booking)
    {
        var entry = new Booking
        {
            Start = booking.Start,
            End = booking.End,
            RoomId = booking.RoomId,
            GuestId = booking.GuestId
        };

        _db.Bookings.Add(entry);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var booking = await _db.Bookings.FindAsync(id);
        if (booking is null) throw new Exception();

        _db.Bookings.Remove(booking);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, BookingEntryDto booking)
    {
        var entity = await _db.Bookings.FindAsync(id);
        if (entity is null) throw new Exception();

        entity.Start = booking.Start;
        entity.End = booking.End;
        entity.RoomId = booking.RoomId;
        entity.GuestId = booking.GuestId;
        _db.Bookings.Update(entity);
        await _db.SaveChangesAsync();
    }
}