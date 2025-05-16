using AutoMapper;
using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Hotel.Service.DTOs;
using Hotel.Service.Services;
using Moq;
using Xunit;

namespace Tests.Unit
{
    public class GuestServiceTests : TestBase
    {
        private readonly Mock<IGuestRepository> _mockGuestRepository;
        private readonly GuestService _guestService;

        public GuestServiceTests()
        {
            _mockGuestRepository = new Mock<IGuestRepository>();
            _guestService = new GuestService(_mockGuestRepository.Object, Mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllGuests()
        {
            var guests = new List<Guest>
            {
                new Guest { Id = 1, FirstName = "Jovan", LastName = "Tone" },
                new Guest { Id = 2, FirstName = "Vangel", LastName = "Tone" }
            };

            _mockGuestRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(guests);

            var result = await _guestService.GetAllAsync();

            Assert.Equal(2, result.Count());
            Assert.Contains(result, g => g.FirstName == "Jovan");
            Assert.Contains(result, g => g.FirstName == "Vangel");
        }

        [Fact]
        public async Task CreateAsync_ValidGuest_ReturnsCreatedGuest()
        {
            var createGuestDto = new CreateGuestDto
            {
                FirstName = "Jovan",
                LastName = "Tone",
                DateOfBirth = new DateTime(2004, 4, 28),
                Address = "Street 21, Temecula",
                Nationality = "American",
                CheckInDate = new DateTime(2025, 5, 15),
                CheckOutDate = new DateTime(2025, 5, 20),
                RoomId = 1
            };

            var createdGuest = new Guest
            {
                Id = 1,
                FirstName = createGuestDto.FirstName,
                LastName = createGuestDto.LastName,
                DateOfBirth = createGuestDto.DateOfBirth,
                Address = createGuestDto.Address,
                Nationality = createGuestDto.Nationality,
                CheckInDate = createGuestDto.CheckInDate,
                CheckOutDate = createGuestDto.CheckOutDate,
                RoomId = createGuestDto.RoomId
            };

            _mockGuestRepository.Setup(repo => repo.CreateAsync(It.IsAny<Guest>()))
                .ReturnsAsync(createdGuest);

            var result = await _guestService.CreateAsync(createGuestDto);

            Assert.Equal(1, result.Id);
            Assert.Equal("Jovan", result.FirstName);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_CallsRepositoryDelete()
        {
            var id = 1;

            await _guestService.DeleteAsync(id);

            _mockGuestRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }
    }
} 