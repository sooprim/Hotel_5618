using AutoMapper;
using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Hotel.Service.DTOs;
using Hotel.Service.Services;
using Moq;
using Xunit;

namespace Tests.Unit
{
    public class RoomServiceTests : TestBase
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly RoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _roomService = new RoomService(_mockRoomRepository.Object, Mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllRooms()
        {
            var rooms = new List<Room>
            {
                new Room { Id = 1, Number = "101", Floor = 1, Type = "Single" },
                new Room { Id = 2, Number = "102", Floor = 1, Type = "Double" }
            };

            _mockRoomRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(rooms);

            var result = await _roomService.GetAllAsync();

            Assert.Equal(2, result.Count());
            Assert.Contains(result, r => r.Number == "101");
            Assert.Contains(result, r => r.Number == "102");
        }

        [Fact]
        public async Task CreateAsync_ValidRoom_ReturnsCreatedRoom()
        {
            var createRoomDto = new CreateRoomDto
            {
                Number = "101",
                Floor = 1,
                Type = "Single"
            };

            var createdRoom = new Room
            {
                Id = 1,
                Number = createRoomDto.Number,
                Floor = createRoomDto.Floor,
                Type = createRoomDto.Type
            };

            _mockRoomRepository.Setup(repo => repo.CreateAsync(It.IsAny<Room>()))
                .ReturnsAsync(createdRoom);

            var result = await _roomService.CreateAsync(createRoomDto);

            Assert.Equal(1, result.Id);
            Assert.Equal("101", result.Number);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_CallsRepositoryDelete()
        {
            var id = 1;

            await _roomService.DeleteAsync(id);

            _mockRoomRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }
    }
} 