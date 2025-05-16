using Hotel.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data.Context
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Guest>()
                .HasOne(g => g.Room)
                .WithMany(r => r.Guests)
                .HasForeignKey(g => g.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 