namespace DataLibrary.Dtos.Booking;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public double Cost { get; set; }
}