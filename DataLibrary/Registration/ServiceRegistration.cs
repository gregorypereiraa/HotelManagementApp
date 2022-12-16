using System.Reflection;
using DataLibrary.Models;
using DataLibrary.Persistence;
using DataLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataLibrary.Registration;

public static class ServiceRegistration
{
     public static IServiceCollection AddHotelManagementData(this IServiceCollection services)
     {
          services.AddDbContext<ApplicationDbContext>(
               option => option.UseSqlServer("Server=localhost;Database=hm;Trusted_Connection=True;TrustServerCertificate=True"));
          
          var assembly = Assembly.GetExecutingAssembly();
          services.AddAutoMapper(assembly);
          
          services.AddTransient<IRoomTypesService, RoomTypesService>();
          services.AddTransient<IRoomService, RoomService>();
          services.AddTransient<IBookingService, BookingService>();
          services.AddTransient<IGuestService, GuestService>();
          
          return services;
     }
}