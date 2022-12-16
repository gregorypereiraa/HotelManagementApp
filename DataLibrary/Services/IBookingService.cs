﻿using DataLibrary.Dtos.Booking;
using DataLibrary.Models;

namespace DataLibrary.Services;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllAsync();
    Task CreateAsync(BookingEntryDto booking);
}