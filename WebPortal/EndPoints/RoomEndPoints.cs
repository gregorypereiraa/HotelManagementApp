using DataLibrary.Dtos.Room;

namespace WebPortal.EndPoints;

public class RoomEndPoints : IRoomEndPoints
{
    private const string HttpClientName = "Default";
    private readonly IHttpClientFactory _httpClientFactory;

    public RoomEndPoints(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<RoomDto>> GetRoomAsync()
    {
        var client = _httpClientFactory.CreateClient(HttpClientName);
        var response = await client.GetAsync("/Room");
        response.EnsureSuccessStatusCode();

        var room = await response.Content.ReadFromJsonAsync<IEnumerable<RoomDto>>();
        return room ?? Enumerable.Empty<RoomDto>();
    }

    public async Task<IEnumerable<RoomDto>> GetRoomAvailableAsync(DateTime from, DateTime to)
    {
        var client = _httpClientFactory.CreateClient(HttpClientName);
        var response = await client.GetAsync($"/Room/Available/{from:yyyy-MM-ddTHH:mm:ssZ}/{to:yyyy-MM-ddTHH:mm:ssZ}");
        response.EnsureSuccessStatusCode();

        var roomAvailable = await response.Content.ReadFromJsonAsync<IEnumerable<RoomDto>>();
        return roomAvailable ?? Enumerable.Empty<RoomDto>();
    }
}