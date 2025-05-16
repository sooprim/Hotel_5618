using AutoMapper;
using Hotel.Data.Context;
using Microsoft.EntityFrameworkCore;
using Hotel.Service.Mapping;

namespace Tests;

public abstract class TestBase : IDisposable
{
    protected readonly HotelDbContext Context;
    protected readonly IMapper Mapper;
    private readonly string _dbName;

    protected TestBase()
    {
        _dbName = $"TestDb_{GetType().Name}_{Guid.NewGuid()}";
        var options = new DbContextOptionsBuilder<HotelDbContext>()
            .UseInMemoryDatabase(databaseName: _dbName)
            .Options;

        Context = new HotelDbContext(options);
        
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        Mapper = mappingConfig.CreateMapper();
    }

    protected async Task ClearDatabase()
    {
        Context.Rooms.RemoveRange(Context.Rooms);
        Context.Guests.RemoveRange(Context.Guests);
        await Context.SaveChangesAsync();
        
        await Context.Database.EnsureDeletedAsync();
        await Context.Database.EnsureCreatedAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
} 