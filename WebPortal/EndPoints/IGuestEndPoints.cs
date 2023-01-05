using DataLibrary.Dtos.Guest;

namespace WebPortal.EndPoints;

public interface IGuestEndPoints
{
    Task<int> CreateGuest(GuestEntryDto guest);
}