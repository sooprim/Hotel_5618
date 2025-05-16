using Microsoft.AspNetCore.Mvc;
using Hotel.Service.DTOs;
using Hotel.Service.Interfaces;

namespace Hotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDto>>> GetAll()
        {
            var guests = await _guestService.GetAllAsync();
            return Ok(guests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetById(int id)
        {
            var guest = await _guestService.GetByIdAsync(id);
            if (guest == null)
                return NotFound();

            return Ok(guest);
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> Create(CreateGuestDto guestDto)
        {
            var createdGuest = await _guestService.CreateAsync(guestDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGuest.Id }, createdGuest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GuestDto>> Update(int id, UpdateGuestDto guestDto)
        {
            try
            {
                var updatedGuest = await _guestService.UpdateAsync(id, guestDto);
                return Ok(updatedGuest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _guestService.DeleteAsync(id);
            return NoContent();
        }
    }
} 