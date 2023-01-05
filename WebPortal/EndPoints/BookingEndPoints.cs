using System.Text;
using DataLibrary.Dtos.Booking;
using Newtonsoft.Json;

namespace WebPortal.EndPoints;

public class BookingEndPoints : IBookingEndPoints
{
    private const string HttpClientName = "Default";
    private readonly IHttpClientFactory _httpClientFactory;

    public BookingEndPoints(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task CreateBooking(BookingEntryDto booking)
    {
        var client = _httpClientFactory.CreateClient(HttpClientName);
        var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/Booking", content);
        response.EnsureSuccessStatusCode();
    }
}