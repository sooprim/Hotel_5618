using AutoMapper;
using Hotel.Data.Entities;
using Hotel.Data.Interfaces;
using Hotel.Service.DTOs;
using Hotel.Service.Interfaces;

namespace Hotel.Service.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;

        public GuestService(IGuestRepository guestRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuestDto>> GetAllAsync()
        {
            var guests = await _guestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GuestDto>>(guests);
        }

        public async Task<GuestDto> GetByIdAsync(int id)
        {
            var guest = await _guestRepository.GetByIdAsync(id);
            return _mapper.Map<GuestDto>(guest);
        }

        public async Task<GuestDto> CreateAsync(CreateGuestDto guestDto)
        {
            var guest = _mapper.Map<Guest>(guestDto);
            var createdGuest = await _guestRepository.CreateAsync(guest);
            return _mapper.Map<GuestDto>(createdGuest);
        }

        public async Task<GuestDto> UpdateAsync(int id, UpdateGuestDto guestDto)
        {
            var existingGuest = await _guestRepository.GetByIdAsync(id);
            if (existingGuest == null)
                throw new KeyNotFoundException($"Guest with ID {id} not found.");

            _mapper.Map(guestDto, existingGuest);
            var updatedGuest = await _guestRepository.UpdateAsync(existingGuest);
            return _mapper.Map<GuestDto>(updatedGuest);
        }

        public async Task DeleteAsync(int id)
        {
            await _guestRepository.DeleteAsync(id);
        }
    }
} 