using AutoMapper;
using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Hotel.Service.DTOs;
using Hotel.Service.Interfaces;

namespace Hotel.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            var createdRoom = await _roomRepository.CreateAsync(room);
            return _mapper.Map<RoomDto>(createdRoom);
        }

        public async Task<RoomDto> UpdateAsync(int id, UpdateRoomDto roomDto)
        {
            var existingRoom = await _roomRepository.GetByIdAsync(id);
            if (existingRoom == null)
                throw new KeyNotFoundException($"Room with ID {id} not found.");

            _mapper.Map(roomDto, existingRoom);
            var updatedRoom = await _roomRepository.UpdateAsync(existingRoom);
            return _mapper.Map<RoomDto>(updatedRoom);
        }

        public async Task DeleteAsync(int id)
        {
            await _roomRepository.DeleteAsync(id);
        }
    }
} 