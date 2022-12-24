using DataLibrary.Dtos.Booking;

namespace DataLibrary.Services;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task CreateAsync(BookingEntryDto booking);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, BookingEntryDto room);
}