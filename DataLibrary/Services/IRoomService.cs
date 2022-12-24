using DataLibrary.Dtos.Room;

namespace DataLibrary.Services;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAllAsync();
    Task CreateAsync(RoomEntryDto room);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, RoomEntryDto room);
    Task<IEnumerable<RoomDto>> GetRoomAvailableAsync(DateTime from, DateTime to);
}