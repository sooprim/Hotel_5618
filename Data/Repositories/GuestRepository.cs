using Hotel.Data.Context;
using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _context;

        public GuestRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _context.Guests.Include(g => g.Room).ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _context.Guests.Include(g => g.Room)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Guest> CreateAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task<Guest> UpdateAsync(Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return guest;
        }

        public async Task DeleteAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }
    }
} 