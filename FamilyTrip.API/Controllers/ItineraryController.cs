using FamilyTrip.Application.DTOs.Itinerary;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FamilyTrip.Application.Contract;
using System.Threading.Tasks;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _itineraryService;

        public ItineraryController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        [HttpPost]
        public async Task<ActionResult<Itinerary>> Create([FromBody] CreateItineraryDto dto)
        {
            var created = await _itineraryService.AddItineraryAsync(dto);
            return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Itinerary>> GetById(int id)
        {
            var itinerary = await _itineraryService.GetByIdAsync(id);
            if (itinerary == null) return NotFound();
            return Ok(itinerary);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateItineraryDto dto)
        {
            var existing = await _itineraryService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            var entity = new Itinerary
            {
                Id = id,
                Date = dto.Date,
                TripId = dto.TripId
            };
            await _itineraryService.UpdateItineraryAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _itineraryService.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _itineraryService.DeleteItineraryAsync(id);
            return NoContent();
        }
    }
}
