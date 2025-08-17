using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.ItineraryItem;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryItemController : ControllerBase
    {
        private readonly IItineraryItemService _service;
        private readonly IMapper _mapper;

        public ItineraryItemController(IItineraryItemService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItineraryItemDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ItineraryItemDto>>(list));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItineraryItemDto>> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<ItineraryItemDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<ItineraryItemDto>> Create(ItineraryItemDto dto)
        {
            var entity = _mapper.Map<ItineraryItem>(dto);
            var created = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ItineraryItemDto>(created));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ItineraryItemDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var existing = await _service.GetByIdAsync(id);
            if (existing is null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
