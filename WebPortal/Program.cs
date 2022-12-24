using WebPortal.Data;
using WebPortal.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient("Default", option => { option.BaseAddress = new Uri("https://localhost:7255/"); });

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<IRoomTypeEndPoints, RoomTypeEndPoints>();
builder.Services.AddTransient<IRoomEndPoints, RoomEndPoints>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();