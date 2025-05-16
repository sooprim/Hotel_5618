using Hotel.Service.DTOs;

namespace Hotel.Service.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestDto>> GetAllAsync();
        Task<GuestDto> GetByIdAsync(int id);
        Task<GuestDto> CreateAsync(CreateGuestDto guestDto);
        Task<GuestDto> UpdateAsync(int id, UpdateGuestDto guestDto);
        Task DeleteAsync(int id);
    }
} 