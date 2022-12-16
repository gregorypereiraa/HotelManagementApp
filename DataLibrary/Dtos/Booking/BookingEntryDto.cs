﻿namespace DataLibrary.Dtos.Booking;

public class BookingEntryDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
}