using DataLibrary.Dtos.Guest;

namespace DataLibrary.Services;

public interface IGuestService
{
    Task<IEnumerable<GuestDto>> GetAllAsync();
    Task<int> CreateAsync(GuestEntryDto guest);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, GuestEntryDto room);
}