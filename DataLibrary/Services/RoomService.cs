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
        var entry = new Room
        {
            RoomNumber = room.RoomNumber,
            RoomTypeId = room.RoomTypeId
        };

        _db.Rooms.Add(entry);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var room = await _db.Rooms.FindAsync(id);
        if (room is null) throw new Exception();

        _db.Rooms.Remove(room);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, RoomEntryDto room)
    {
        var entity = await _db.Rooms.FindAsync(id);
        if (entity is null) throw new Exception();

        entity.RoomTypeId = room.RoomTypeId;
        entity.RoomNumber = room.RoomNumber;
        _db.Rooms.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoomDto>> GetRoomAvailableAsync(DateTime from, DateTime to)
    {
        var rooms = await _db.Rooms.ToListAsync();
        var bookedRooms = await _db.Bookings
            .Where(x => (x.Start < from && x.End > from) || (x.Start > to && x.End < to))
            .Select(x => x.RoomId)
            .ToListAsync();

        var availableRooms = rooms.Where(r => !bookedRooms.Contains(r.Id)).ToList();

        return availableRooms.Select(x => _mapper.Map<RoomDto>(x));
    }
}