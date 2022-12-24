using DataLibrary.Dtos.RoomType;

namespace DataLibrary.Services;

public interface IRoomTypesService
{
    Task<IEnumerable<RoomTypeDto>> GetAllAsync();
    Task CreateAsync(RoomTypeEntryDto roomType);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, RoomTypeEntryDto roomType);
}