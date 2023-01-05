using DataLibrary.Dtos.Booking;

namespace WebPortal.EndPoints;

public interface IBookingEndPoints
{
    Task CreateBooking(BookingEntryDto booking);
}