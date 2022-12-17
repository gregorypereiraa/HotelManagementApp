using AutoMapper;
using DataLibrary.Dtos.Booking;
using DataLibrary.Dtos.Guest;
using DataLibrary.Dtos.Room;
using DataLibrary.Dtos.RoomType;

namespace DataLibrary.Dtos;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Room, RoomDto>();
        CreateMap<Models.Booking,BookingDto>();
        CreateMap<Models.RoomType, RoomTypeDto>();
        CreateMap<Models.Guest, GuestDto>();
    }
}