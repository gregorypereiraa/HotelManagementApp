using AutoMapper;
using DataLibrary.Dtos.Guest;
using DataLibrary.Models;
using DataLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Services;

public class GuestService : IGuestService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public GuestService(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GuestDto>> GetAllAsync()
    {
        var guests = await _db.Guests.ToListAsync();

        var guestsDto = guests.Select(x => _mapper.Map<GuestDto>(x));
        return guestsDto;
    }

    public async Task CreateAsync(GuestEntryDto guest)
    {
        var entry = new Guest
        {
            FirstName = guest.FirstName,
            LastName = guest.LastName
        };
        _db.Guests.Add(entry);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var guest = await _db.Guests.FindAsync(id);
        if (guest is null) throw new Exception();

        _db.Guests.Remove(guest);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, GuestEntryDto guest)
    {
        var entity = await _db.Guests.FindAsync(id);
        if (entity is null) throw new Exception();

        entity.FirstName = guest.FirstName;
        entity.LastName = guest.LastName;
        _db.Guests.Update(entity);
        await _db.SaveChangesAsync();
    }
}