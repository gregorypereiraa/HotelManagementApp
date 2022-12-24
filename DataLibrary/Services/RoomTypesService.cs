using AutoMapper;
using DataLibrary.Dtos.RoomType;
using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class RoomTypesService : IRoomTypesService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public RoomTypesService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoomTypeDto>> GetAllAsync()
    {
        var roomTypes = await _db.RoomTypes.AsNoTracking().ToListAsync();
        var roomTypesDto = roomTypes.Select(x => _mapper.Map<RoomTypeDto>(x));
        return roomTypesDto;
    }

    public async Task CreateAsync(RoomTypeEntryDto roomType)
    {
        var entry = new RoomType
        {
            Title = roomType.Title,
            Description = roomType.Description,
            Price = roomType.Price
        };
        _db.RoomTypes.Add(entry);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var roomType = await _db.RoomTypes.FindAsync(id);
        if (roomType is null) throw new Exception();

        _db.RoomTypes.Remove(roomType);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, RoomTypeEntryDto roomType)
    {
        var entity = await _db.RoomTypes.FindAsync(id);
        if (entity is null) throw new Exception();

        entity.Title = roomType.Title;
        entity.Description = roomType.Description;
        entity.Price = roomType.Price;
        _db.RoomTypes.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<RoomType?> GetById(int id)
    {
        var roomType = await _db.RoomTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        return roomType;
    }
}