using Hotel.Data.Entities;

namespace Hotel.Data.Interfaces
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAllAsync();
        Task<Guest> GetByIdAsync(int id);
        Task<Guest> CreateAsync(Guest guest);
        Task<Guest> UpdateAsync(Guest guest);
        Task DeleteAsync(int id);
    }
} 