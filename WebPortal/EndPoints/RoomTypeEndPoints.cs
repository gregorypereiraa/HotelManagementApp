using DataLibrary.Dtos.RoomType;

namespace WebPortal.EndPoints;

public class RoomTypeEndPoints : IRoomTypeEndPoints
{
    private const string HttpClientName = "Default";
    private readonly IHttpClientFactory _httpClientFactory;

    public RoomTypeEndPoints(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<RoomTypeDto>> GetRoomTypesAsync()
    {
        var client = _httpClientFactory.CreateClient(HttpClientName);
        var response = await client.GetAsync("/RoomTypes");
        response.EnsureSuccessStatusCode();

        var roomTypes = await response.Content.ReadFromJsonAsync<IEnumerable<RoomTypeDto>>();
        return roomTypes ?? Enumerable.Empty<RoomTypeDto>();
    }
}