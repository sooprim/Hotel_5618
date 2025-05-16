using Hotel.Service.DTOs;

namespace Hotel.Service.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int id);
        Task<RoomDto> CreateAsync(CreateRoomDto roomDto);
        Task<RoomDto> UpdateAsync(int id, UpdateRoomDto roomDto);
        Task DeleteAsync(int id);
    }
} 