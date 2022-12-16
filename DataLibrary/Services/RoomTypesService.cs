using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class RoomTypesService : IRoomTypesService
{
    private readonly ApplicationDbContext _db;

    public RoomTypesService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<RoomType>> GetAllAsync()
    {
        var roomTypes = await _db.RoomTypes.ToListAsync();
        return roomTypes;
    }

    public async Task CreateAsync(RoomType roomType)
    {
         _db.RoomTypes.Add(roomType);
         await _db.SaveChangesAsync();
    }
}