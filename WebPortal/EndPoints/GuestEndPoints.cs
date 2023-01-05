using System.Text;
using DataLibrary.Dtos.Guest;
using Newtonsoft.Json;

namespace WebPortal.EndPoints;

public class GuestEndPoints : IGuestEndPoints
{
    private const string HttpClientName = "Default";
    private readonly IHttpClientFactory _httpClientFactory;

    public GuestEndPoints(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<int> CreateGuest(GuestEntryDto guest)
    {
        var client = _httpClientFactory.CreateClient(HttpClientName);
        var content = new StringContent(JsonConvert.SerializeObject(guest), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/Guest", content);
        response.EnsureSuccessStatusCode();

        var id = await response.Content.ReadFromJsonAsync<int>();
        return id;
    }
}