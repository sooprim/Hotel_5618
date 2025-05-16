using AutoMapper;
using Hotel.Data.Entities;
using Hotel.Service.DTOs;

namespace Hotel.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Guest, GuestDto>();
        CreateMap<CreateGuestDto, Guest>();
        CreateMap<UpdateGuestDto, Guest>();

        CreateMap<Room, RoomDto>();
        CreateMap<CreateRoomDto, Room>();
        CreateMap<UpdateRoomDto, Room>();
    }
} 