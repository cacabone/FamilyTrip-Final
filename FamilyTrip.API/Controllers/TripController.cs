using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.Trip;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public TripController(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDto>>> GetAll()
        {
            var trips = await _tripService.GetAllTripsAsync();
            var dtos = _mapper.Map<IEnumerable<TripDto>>(trips);
            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TripDto>> GetById(int id)
        {
            var trip = await _tripService.GetTripByIdAsync(id);
            if (trip is null) return NotFound();
            return Ok(_mapper.Map<TripDto>(trip));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripDto createTripDto)
        {
            await _tripService.AddTripAsync(createTripDto);
            return Ok("Trip created successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TripDto dto)
        {
            if (id != dto.Id) return BadRequest("El id del path no coincide con el del cuerpo.");

            var existing = await _tripService.GetTripByIdAsync(id);
            if (existing is null) return NotFound();

            _mapper.Map(dto, existing);
            await _tripService.UpdateTripAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _tripService.GetTripByIdAsync(id);
            if (existing is null) return NotFound();

            await _tripService.DeleteTripAsync(id);
            return NoContent();
        }
    }
}
