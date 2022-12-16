using DataLibrary.Models;

namespace DataLibrary.Services;

public interface IGuestService
{
    Task<IEnumerable<Guest>> GetAllAsync();
    Task CreateAsync(Guest guest);
}