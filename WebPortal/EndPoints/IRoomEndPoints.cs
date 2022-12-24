using DataLibrary.Dtos.Room;

namespace WebPortal.EndPoints;

public interface IRoomEndPoints
{
    Task<IEnumerable<RoomDto>> GetRoomAsync();
    Task<IEnumerable<RoomDto>> GetRoomAvailableAsync(DateTime from, DateTime to);
}