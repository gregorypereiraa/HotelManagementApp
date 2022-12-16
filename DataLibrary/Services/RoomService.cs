using AutoMapper;
using DataLibrary.Dtos.Room;
using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class RoomService : IRoomService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public RoomService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<RoomDto>> GetAllAsync()
    {
        var rooms = await _db.Rooms
            .ToListAsync();

        var roomsDto = rooms.Select(x => _mapper.Map<RoomDto>(x));
        return roomsDto;
    }

    public async Task CreateAsync(RoomEntryDto room)
    {
        var entry = new Room()
        {
            RoomNumber = room.RoomNumber,
            RoomTypeId = room.RoomTypeId
        };
        
        _db.Rooms.Add(entry);
        await _db.SaveChangesAsync();
    }
}
    