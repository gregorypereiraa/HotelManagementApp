using AutoMapper;
using DataLibrary.Dtos.Booking;
using DataLibrary.Dtos.Room;

namespace DataLibrary.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Room, RoomDto>();
        CreateMap<Models.Booking,BookingDto>();
    }
}