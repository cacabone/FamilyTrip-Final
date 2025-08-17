using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.PackingList;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackingController : ControllerBase
    {
        private readonly IPackingListService _service;
        private readonly IMapper _mapper;

        public PackingController(IPackingListService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingItemDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PackingItemDto>>(list));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PackingItemDto>> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<PackingItemDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<PackingItemDto>> Create(PackingItemDto dto)
        {
            var entity = _mapper.Map<PackingItem>(dto);
            var created = await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<PackingItemDto>(created));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PackingItemDto dto)
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

        [HttpPost("list")]
        public async Task<ActionResult<PackingListDto>> CreatePackingList(CreatePackingListDto dto)
        {
            var created = await _service.CreatePackingListAsync(dto);
            return CreatedAtAction(nameof(GetPackingListById), new { id = created.Id }, created);
        }

        [HttpGet("list/{id:int}")]
        public async Task<ActionResult<PackingListDto>> GetPackingListById(int id)
        {
            var entity = await _service.GetPackingListByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(entity);
        }

        [HttpGet("lists")]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> GetAllPackingLists()
        {
            var lists = await _service.GetAllPackingListsAsync();
            return Ok(lists);
        }

        [HttpPut("list/{id:int}")]
        public async Task<IActionResult> UpdatePackingList(int id, CreatePackingListDto dto)
        {
            var existing = await _service.GetPackingListByIdAsync(id);
            if (existing is null) return NotFound();
            // Map updated fields
            var entity = _mapper.Map<PackingList>(dto);
            entity.Id = id;
            // You may want to update only TripId and UserId, not Items
            await _service.UpdatePackingListAsync(entity);
            return NoContent();
        }

        [HttpDelete("list/{id:int}")]
        public async Task<IActionResult> DeletePackingList(int id)
        {
            var existing = await _service.GetPackingListByIdAsync(id);
            if (existing is null) return NotFound();
            await _service.DeletePackingListAsync(id);
            return NoContent();
        }
    }
}
