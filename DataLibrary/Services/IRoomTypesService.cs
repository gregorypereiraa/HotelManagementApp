using DataLibrary.Models;

namespace DataLibrary.Services;

public interface IRoomTypesService
{
    Task<IEnumerable<RoomType>> GetAllAsync();
    Task CreateAsync(RoomType roomType);
}