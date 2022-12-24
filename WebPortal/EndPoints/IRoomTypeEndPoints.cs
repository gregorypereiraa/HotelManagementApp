using DataLibrary.Dtos.RoomType;

namespace WebPortal.EndPoints;

public interface IRoomTypeEndPoints
{
    Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync();
}