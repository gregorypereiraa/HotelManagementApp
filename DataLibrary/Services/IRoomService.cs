using DataLibrary.Dtos.Room;
using DataLibrary.Models;

namespace DataLibrary.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAllAsync();
    Task CreateAsync(RoomEntryDto room);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, RoomEntryDto room);
}