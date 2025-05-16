using Hotel.Data.Entities;

namespace Hotel.Data.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task<Room> CreateAsync(Room room);
        Task<Room> UpdateAsync(Room room);
        Task DeleteAsync(int id);
    }
} 