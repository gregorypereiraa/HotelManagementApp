using DataLibrary.Dtos.Room;
using DataLibrary.Models;

namespace DataLibrary.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAllAsync();
    Task CreateAsync(RoomEntryDto room);
}