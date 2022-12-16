using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class GuestService : IGuestService
{
    private readonly ApplicationDbContext _db;

    public GuestService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<Guest>> GetAllAsync()
    {
        var guest = await _db.Guests.ToListAsync();
        return guest;
    }

    public async Task CreateAsync(Guest guest)
    {
        _db.Guests.Add(guest);
        await _db.SaveChangesAsync();
    }
}